using Microsoft.EntityFrameworkCore;
using Tennis4u_API.Data;
using Tennis4u_API.DTOs.Responses;
using Tennis4u_API.Repositories.Interfaces;

namespace Tennis4u_API.Repositories.Implementations
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ClientProfileNavResponseDTO?> GetClientProfileNavDetailsAsync(int idClient)
        {
            return await _context.Clients.Where(c => c.IdPerson == idClient).Select(c => new ClientProfileNavResponseDTO
            {
                IdClient = c.IdPerson,
                Name = c.FirstName + " " + c.LastName
            }).SingleOrDefaultAsync();
        }

        public async Task<List<ClientForReservationResponseDTO>> GetClientsForReservationAsync()
        {
            return await _context.Clients.Select(c => new ClientForReservationResponseDTO
            {
                IdClient = c.IdPerson,
                Name = c.FirstName + " " + c.LastName,
            }).ToListAsync();
        }

        public async Task<ClientDetailResponseDTO?> GetClientDetailResponseAsync(int idClient)
        {
            return await _context.Clients.Where(c => c.IdPerson == idClient).Select(c => new ClientDetailResponseDTO
            {
                IdClient = c.IdPerson,
                Name = c.FirstName + " " + c.LastName,
                DateOfBirth = c.DateOfBirth,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                NumberOfWonMatches = c.MatchesOne.Where(m => m.IdWinner == idClient).Count()
            }).SingleOrDefaultAsync();
        }

        public async Task<List<ClientReservation>> GetClientReservationsAsync(int idClient)
        {
            var nowDate = DateTime.Now.AddDays(1);
            return await _context.Reservations.Where(r => r.IdPerson == idClient).OrderByDescending(r => r.ReservationDate).ThenByDescending(r => r.StartReservation).Select(r => new ClientReservation
            {
                IdReservation = r.IdReservation,
                IdTennisClub = r.IdTennisCourtNavigation.IdTennisClub,
                Status = r.IdStateNavigation.Name,
                CourtNumber = r.IdTennisCourtNavigation.Number,
                TennisClubName = r.IdTennisCourtNavigation.IdTennisClubNavigation.Name,
                ReservationRange = r.ReservationDate.Date.ToString() + " " + r.StartReservation.ToString("hh\\:mm") + "-" + r.EndReservation.ToString("hh\\:mm"),
                Price = (double)r.IdTennisCourtNavigation.Price * ((r.EndReservation - r.StartReservation).TotalHours),
                IsAvailableToCancel = r.IdState == 2 && r.ReservationDate > nowDate
            }).ToListAsync();
        }

        public async Task<List<ClientMatchResponseDTO>> GetClientMatchesAsync(int idClient)
        {
            return await _context.Matches.Where(m => m.IdClientOne == idClient || m.IdClientTwo == idClient).Select(m => new ClientMatchResponseDTO
            {
                IdTournament = m.IdTournament,
                TournamentName = m.IdTournamentNavigation.Name,
                StageTournament = m.IdStageTournamentNavigation.Name,
                ResultMatch = m.Result,
                MatchDate = m.IdReservationNavigation.ReservationDate.Date.ToString() + " " + m.IdReservationNavigation.StartReservation.ToString("hh\\:mm") + "-" + m.IdReservationNavigation.EndReservation.ToString("hh\\:mm"),
                OpponentId = m.IdClientOne == idClient ? m.IdClientTwo : m.IdClientOne,
                OpponentName = m.IdClientOne == idClient ? m.IdClientTwoNavigation.FirstName + " " + m.IdClientTwoNavigation.LastName : m.IdClientOneNavigation.FirstName + " " + m.IdClientOneNavigation.LastName,
                IsWinner = m.IdWinner == idClient
            }).ToListAsync();
        }
    }
}
