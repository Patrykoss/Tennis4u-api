using Microsoft.EntityFrameworkCore;
using Tennis4u_API.Data;
using Tennis4u_API.DTOs.Requests;
using Tennis4u_API.DTOs.Responses;
using Tennis4u_API.Models;
using Tennis4u_API.Repositories.Interfaces;
using Tennis4u_API.Utils;

namespace Tennis4u_API.Repositories.Implementations
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly AppDbContext _context;

        public TournamentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<TournamentInListResponseDTO>> GetTournamentsAsync()
        {
            return await _context.Tournaments.Select(t => new TournamentInListResponseDTO
            {
                IdTournament = t.IdTournament,
                TournamentName = t.Name,
                Rank = t.Rank,
                StartDate = t.StartDate,
                IdTennisClub = t.IdTennisClub,
                TennisClubName = t.IdTennisClubNavigation.Name
            }).OrderByDescending(t => t.StartDate).ToListAsync(); ;
        }

        public async Task<List<TournamentInListResponseDTO>> GetClubTournamentsAsync(int idTennisClub)
        {
            var tournaments = await _context.Tournaments.Where(t => t.IdTennisClub == idTennisClub).Select(t => new TournamentInListResponseDTO
            {
                IdTournament = t.IdTournament,
                TournamentName = t.Name,
                Rank = t.Rank,
                StartDate = t.StartDate,
                IdWinner = t.Matches.Where(m => m.IdStage == 1).Select(m => m.IdWinner).SingleOrDefault(),
                IdTennisClub = t.IdTennisClub,
                HasReservations = t.Matches.Any(m => m.IdReservation != null)
            }).OrderByDescending(t => t.StartDate).ToListAsync();
            foreach (var tournament in tournaments)
            {
                tournament.WinnerName = await _context.Persons.Where(p => p.IdPerson == tournament.IdWinner).Select(p => p.FirstName + " " + p.LastName).SingleOrDefaultAsync();
            };
            return tournaments;
        }

        public async Task<TournamentStatus> DeleteTournamentByIdAsync(int idTournament)
        {
            var tournament = await _context.Tournaments.SingleOrDefaultAsync(t => t.IdTournament == idTournament);
            if (tournament == null)
                return TournamentStatus.TournamentNotExist;
            _context.Tournaments.Remove(tournament);
            if (!(await _context.SaveChangesAsync() > 0))
                return TournamentStatus.DbError;
            return TournamentStatus.TournamentDeleted;
        }

        public async Task<bool> IsWorkerManageOfTournament(int? idWorker, int idTournament)
        {
            return await _context.Tournaments.Where(t => t.IdTournament == idTournament)
                .Select(t => t.IdTennisClubNavigation.Workers.Where(tc => tc.IdPerson == idWorker) != null).SingleOrDefaultAsync();
        }

        public async Task<TournamentDetailsResponseDTO?> GetTournamentDetailsAsync(int idTournament, int? idUser, bool isClient)
        {
            return await _context.Tournaments.Where(t => t.IdTournament == idTournament).Select(t => new TournamentDetailsResponseDTO
            {
                IdTennisClub = t.IdTennisClub,
                IdTournament = t.IdTournament,
                TournamentName = t.Name,
                StartDate = t.StartDate,
                EndDate = t.EndDate,
                EndDateOfRegistration = t.FinalDateForRegistration,
                NumberOfPlayers = t.Registrations.Count() + "/" + t.MaxNumberOfPlayers,
                Rank = t.Rank,
                CanPlay = new DateTime() < t.FinalDateForRegistration && t.Registrations.Count() < t.MaxNumberOfPlayers && !t.Registrations.Any(r=> r.IdClient == idUser) && isClient
            }).SingleOrDefaultAsync();
        }

        public async Task<TournamentStatus> RegisterForTournamentAsync(int idTournament, int? idUser)
        {
            var registration = new Registration
            {
                IdClient = idUser.Value,
                IdTournament = idTournament
            };
            await _context.Registrations.AddAsync(registration);
            if (!(await _context.SaveChangesAsync() > 0))
                return TournamentStatus.DbError;
            return TournamentStatus.Success;
        }

        public async Task<List<PlayerOfTournamentResponseDTO>> GetPlayersOfTournamentAsync(int idTournament)
        {
            return await _context.Registrations.Where(r => r.IdTournament == idTournament).Select(p => new PlayerOfTournamentResponseDTO
            {
                IdPlayer = p.IdClient,
                PlayerName = p.IdClientNavigation.FirstName + " " + p.IdClientNavigation.LastName
            }).ToListAsync();
        }

        public async Task<List<MatchOfTournamentResponseDTO>> GetMatchesOfTournamentAsync(int idTournament)
        {
            return await _context.Matches.Where(m => m.IdTournament == idTournament).Select(m => new MatchOfTournamentResponseDTO
            {
                IdTennisClub = m.IdTournamentNavigation.IdTennisClub,
                IdMatch = m.IdMatch,
                IdClientOne = m.IdClientOne,
                IdClientTwo = m.IdClientTwo,
                NameOne = m.IdClientOneNavigation.FirstName + " " + m.IdClientOneNavigation.LastName,
                NameTwo = m.IdClientTwoNavigation.FirstName + " " + m.IdClientTwoNavigation.LastName,
                IdWinner = m.IdWinner,
                DateOfMatch = m.IdReservation==null ? null : m.IdReservationNavigation.ReservationDate.Date.ToString() + " " + m.IdReservationNavigation.StartReservation.ToString("hh\\:mm") + "-" + m.IdReservationNavigation.EndReservation.ToString("hh\\:mm"),
                DateOfStart = m.IdTournamentNavigation.StartDate.Date,
                Result = m.Result,
                Stage = m.IdStageTournamentNavigation.Name
            }).ToListAsync();
        }

        public async Task<TournamentNavResponseDTO?> GetTournamentNavDetailsAsync(int idTournament)
        {
            return await _context.Tournaments.Where(t => t.IdTournament == idTournament).Select(t => new TournamentNavResponseDTO
            {
                IdTournament = t.IdTournament,
                TournamentName = t.Name
            }).SingleOrDefaultAsync();
        }

        public async Task<Tuple<bool,ReservationMatchResponseDTO>> GetAvailablePlayersForMatchAsync(int idTournament, int idMatch, int? idClub)
        {
            var match = await _context.Matches.Where(m => m.IdTournamentNavigation.IdTennisClub == idClub && m.IdMatch == idMatch).Select(m => new 
            {
                TournamentStageName = m.IdStageTournamentNavigation.Name + " " + m.IdTournamentNavigation.Name,
                Stage = m.IdStage,
                LastStage = _context.Matches.Max(m => m.IdStage)
            }).SingleOrDefaultAsync();
            if(match == null)
                return new ( false, null );
            var registeredPlayers = new List<ClientShortDetailsResponseDTO>();
            if (match.Stage == match.LastStage)
                registeredPlayers = await _context.Registrations.Where(r => r.IdTournament == idTournament && !_context.Matches.Any(m => m.IdTournament == idTournament && (m.IdClientTwo == r.IdClient || m.IdClientOne == r.IdClient))).Select(r => new ClientShortDetailsResponseDTO
                {
                    IdClient = r.IdClient,
                    Name = r.IdClientNavigation.FirstName + " " + r.IdClientNavigation.LastName
                }).ToListAsync();
            else
            {
                List<int?> winnersOfLastPage = await _context.Matches.Where(m => m.IdTournament == idTournament && m.IdStage == match.Stage + 1 && m.IdWinner != null).Select(m => m.IdWinner).ToListAsync();
                registeredPlayers = await _context.Registrations.Where(r => r.IdTournament == idTournament && winnersOfLastPage.Contains(r.IdClient)).Select(r => new ClientShortDetailsResponseDTO
                {
                    IdClient = r.IdTournament,
                    Name = r.IdClientNavigation.FirstName + " " + r.IdClientNavigation.LastName
                }).ToListAsync();
            }
                
            var result = new ReservationMatchResponseDTO
            {
                TournamentStageName = match.TournamentStageName,
                Players = registeredPlayers
            };
            return new(true, result);
        }

        public async Task<int?> GetIdTournamentAsync(int idMatch)
        {
            var res = await _context.Matches.SingleOrDefaultAsync(m => m.IdMatch == idMatch);
            return res.IdTournament;
        }

        public async Task<Tuple<TournamentStatus, Tournament>> CreateTournamentAsync(CreateTournamentRequestDTO createTournamentDto, int idTennisClub)
        {
            var tournament = new Tournament
            {
                Name = createTournamentDto.Name,
                Rank = createTournamentDto.Rank,
                StartDate = createTournamentDto.StartDate,
                EndDate = createTournamentDto.EndDate,
                MaxNumberOfPlayers = createTournamentDto.MaxPlayers,
                FinalDateForRegistration = createTournamentDto.FinalDateForRegistration,
                IdTennisClub = idTennisClub
            };
            await _context.AddAsync(tournament);
            if (!(await _context.SaveChangesAsync() > 0))
                return new(TournamentStatus.DbError,null);

            return new(TournamentStatus.Success, tournament);
        }


        public async Task<TournamentStatus> UpdateTournamentAsync(TournamentUpdateRequestDTO tournamentUpdateDto)
        {
            var tournament = await _context.Tournaments.SingleOrDefaultAsync(t => t.IdTournament == tournamentUpdateDto.IdTournament);
            if (tournament == null)
                return TournamentStatus.TournamentNotExist;
            tournament.Name = tournamentUpdateDto.Name;
            tournament.Rank = tournamentUpdateDto.Rank;
            tournament.StartDate = tournamentUpdateDto.StartDate;
            tournament.EndDate = tournamentUpdateDto.EndDate;
            tournament.MaxNumberOfPlayers = tournamentUpdateDto.MaxPlayers;
            tournament.FinalDateForRegistration = tournamentUpdateDto.FinalDateForRegistration;

            if (!(await _context.SaveChangesAsync() > 0))
                return TournamentStatus.DbError;

            return TournamentStatus.Success;
        }

        public async Task<bool> AssignMatches(Tournament tournament)
        {
            for (int x = 1, c = 1, d =1; x < tournament.MaxNumberOfPlayers; x = x * 2, d++)
            {
                for (int i = 1; i <= x && c < tournament.MaxNumberOfPlayers; i++)
                {
                    var match = new Match()
                    {
                        IdStage = d,
                        IdTournament = tournament.IdTournament
                    };
                    await _context.AddAsync(match);
                    c++;
                }
            }

            if (!(await _context.SaveChangesAsync() > 0))
                return false;
            return true;
        }
    }
}