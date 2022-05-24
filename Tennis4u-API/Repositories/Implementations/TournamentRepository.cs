using Microsoft.EntityFrameworkCore;
using Tennis4u_API.Data;
using Tennis4u_API.DTOs.Responses;
using Tennis4u_API.Repositories.Interfaces;

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
            var tournaments = await _context.Tournaments.Select(t => new TournamentInListResponseDTO
            {
                IdTournament = t.IdTournament,
                TournamentName = t.Name,
                Rank = t.Rank,
                StartDate = t.StartDate,
                IdWinner = t.Matches.Where(m => m.IdStage == 1).Select(m => m.IdWinner).SingleOrDefault(),
                IdTennisClub = t.IdTennisClub,
                TennisClubName = t.IdTennisClubNavigation.Name
            }).ToListAsync();
            foreach (var tournament in tournaments)
            {
                tournament.WinnerName = await _context.Persons.Where(p => p.IdPerson == tournament.IdWinner).Select(p => p.FirstName + " " + p.LastName).SingleOrDefaultAsync();
            };
            return tournaments;
        }
    }
}