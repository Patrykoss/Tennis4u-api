using Microsoft.EntityFrameworkCore;
using Tennis4u_API.Data;
using Tennis4u_API.DTOs.Requests;
using Tennis4u_API.DTOs.Responses;
using Tennis4u_API.Repositories.Interfaces;
using Tennis4u_API.Utils;

namespace Tennis4u_API.Repositories.Implementations
{
    public class MatchRepository : IMatchRepository
    {
        private readonly AppDbContext _context;

        public MatchRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<MatchResponseDTO?> GetMatchDetailsAsync(int idMatch)
        {
            return await _context.Matches.Where(m => m.IdMatch == idMatch).Select(m => new MatchResponseDTO
            {
                IdMatch = idMatch,
                PlayerOneName = m.IdClientOneNavigation.FirstName + " " + m.IdClientOneNavigation.LastName,
                PlayerTwoName = m.IdClientTwoNavigation.FirstName + " " + m.IdClientTwoNavigation.LastName,
                StageName = m.IdStageTournamentNavigation.Name,
                Players = new() { 
                    new () { IdClient = m.IdClientOne.Value, Name = m.IdClientOneNavigation.FirstName + " " + m.IdClientOneNavigation.LastName  },
                    new () { IdClient = m.IdClientTwo.Value, Name = m.IdClientTwoNavigation.FirstName + " " + m.IdClientTwoNavigation.LastName  },
                },
                DateOfMatch = m.IdReservationNavigation.ReservationDate.Date.ToString() + " " + m.IdReservationNavigation.StartReservation.ToString("hh\\:mm") + "-" + m.IdReservationNavigation.EndReservation.ToString("hh\\:mm")
            }).SingleOrDefaultAsync();
        }

        public async Task<MatchStatus> UpdateResult(MatchResultRequestDTO matchResultDto)
        {
            var match = await _context.Matches.SingleOrDefaultAsync(m => m.IdMatch == matchResultDto.IdMatch);
            if (match == null)
                return MatchStatus.NotExist;
            match.IdWinner = matchResultDto.IdWinner;
            match.Result = matchResultDto.Result;
            if (!(await _context.SaveChangesAsync() > 0))
                return MatchStatus.DbError;
            return MatchStatus.Success;
        }
    }
}
