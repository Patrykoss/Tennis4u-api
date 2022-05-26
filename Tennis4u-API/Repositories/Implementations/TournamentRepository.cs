using Microsoft.EntityFrameworkCore;
using Tennis4u_API.Data;
using Tennis4u_API.DTOs.Responses;
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
                IdTennisClub = t.IdTennisClub
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
    }
}