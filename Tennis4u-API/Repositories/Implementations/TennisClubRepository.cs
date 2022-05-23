using Microsoft.EntityFrameworkCore;
using Tennis4u_API.Data;
using Tennis4u_API.DTOs.Responses;
using Tennis4u_API.Repositories.Interfaces;

namespace Tennis4u_API.Repositories.Implementations
{
    public class TennisClubRepository : ITennisClubRepository
    {
        private readonly AppDbContext _context;

        public TennisClubRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TennisClubResponseDTO?> GetTennisClubInfoAsync(int idTennisClub)
        {
            return await _context.TennisClubs.Where(t => t.IdTennisClub == idTennisClub).Select(t => new TennisClubResponseDTO
            {
                IdTennisClub = t.IdTennisClub,
                ClubName = t.Name,
                Email = t.Email,
                Website = t.Website,
                PhoneNumbers = new List<string> { t.PhoneNumbers },
                City = t.City,
                Street = t.Street,
                PostCode = t.PostCode,
                Logo = t.Logo,
                WorkDays = t.WorkDays.Select(w => new WorkDayResponseDTO
                {
                    Day = w.IdDayNavigation.Name,
                    OpenHour = w.OpenHour,
                    CloseHour = w.CloseHour
                }).ToList()
            }).SingleOrDefaultAsync();
        }

        public async Task<List<TennisClubResponseDTO>> GetTennisClubsAsync()
        {
            return await _context.TennisClubs.Select(t => new TennisClubResponseDTO
            {
                IdTennisClub = t.IdTennisClub,
                ClubName = t.Name,
                City = t.City,
                Street = t.Street,
                Logo = t.Logo
            }).ToListAsync();
        }
    }
}
