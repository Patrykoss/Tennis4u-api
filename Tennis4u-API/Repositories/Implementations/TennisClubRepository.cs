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
                    DayName = w.IdDayNavigation.Name,
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

        public async Task<ClubHoursResponseDTO> GetWorkingHoursByDayAsync(int idTennisClub, DateTime dateOfWork)
        {
            var idDay = (int)dateOfWork.DayOfWeek == 0 ? 7 : (int)dateOfWork.DayOfWeek;
            var clubInfo = await _context.WorkDays.Where(w => w.IdDay == idDay && w.IdTennisClub == idTennisClub).Select(w => new
            {
                OpenHour = w.OpenHour,
                CloseHour = w.CloseHour,
                Courts = w.IdTenniClubNavigation.TennisCourts.Select(c => new TennisCourtInScheduleResponseDTO
                {
                    IdTennisClub = c.IdTennisClub,
                    IdTennisCourt = c.IdTennisCourt,
                    Number = c.Number,
                    Roof = c.IdRoofNavigation.Name,
                    Surface = c.IdSurfaceNavigation.Name
                }).ToList()
            }).SingleOrDefaultAsync();
            var workingHours = new List<WorkingHourResponseDTO>();
            if (clubInfo == null)
                return null;
            var hoursDiff = (clubInfo.CloseHour - clubInfo.OpenHour).TotalHours;
            for (int i = 0; i < hoursDiff; i++)
            {
                var h = clubInfo.OpenHour.Add(new TimeSpan(i, 0, 0));
                workingHours.Add(new WorkingHourResponseDTO
                {
                    Hour = string.Format("{0}:{1:00}", h.Hours, h.Minutes)
                });
            }

            return new ClubHoursResponseDTO
            {
                WorkHours = workingHours,
                Courts = clubInfo.Courts
            };
        }
    }
}
