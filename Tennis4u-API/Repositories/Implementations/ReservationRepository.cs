using Microsoft.EntityFrameworkCore;
using Tennis4u_API.Data;
using Tennis4u_API.DTOs.Requests;
using Tennis4u_API.DTOs.Responses;
using Tennis4u_API.Models;
using Tennis4u_API.Repositories.Interfaces;
using Tennis4u_API.Utils;

namespace Tennis4u_API.Repositories.Implementations
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly AppDbContext _context;

        public ReservationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ReservationDetailsResponseDTO> GetInfoForReservationAsync(int idTennisCourt, DateTime dateReservation, TimeSpan timeReservation)
        {
            var reservationDetail = await _context.TennisCourts.Where(t => t.IdTennisCourt == idTennisCourt).Select(r => new ReservationDetailsResponseDTO
            {
                IdTennisClub = r.IdTennisClub,
                IdTennisCourt = idTennisCourt,
                Number = r.Number,
                Price = r.Price,
                Roof = r.IdRoofNavigation.Name,
                Surface = r.IdSurfaceNavigation.Name,
                IsLight = r.IsLight,
                ResDate = dateReservation.ToString("dd/MM/yyyy") + " " + string.Format("{0}:{1:00}", timeReservation.Hours, timeReservation.Minutes),
                AvailableHours = new List<string>(){string.Format("{0}:{1:00}", timeReservation.Hours, timeReservation.Minutes) + " - " + string.Format("{0}:{1:00}", timeReservation.Add(new TimeSpan(1, 0, 0)).Hours, timeReservation.Minutes) }
            }).SingleOrDefaultAsync();
            var newHour = timeReservation.Add(new TimeSpan(1, 0, 0));
            var isNextHourAvailable = await _context.Reservations.SingleOrDefaultAsync(r => r.ReservationDate == dateReservation && r.StartReservation == newHour && r.IdTennisCourt == idTennisCourt);
            if (isNextHourAvailable == null)
                reservationDetail.AvailableHours.Add(string.Format("{0}:{1:00}", timeReservation.Hours, timeReservation.Minutes) + " - " + string.Format("{0}:{1:00}", timeReservation.Add(new TimeSpan(2, 0, 0)).Hours, timeReservation.Minutes));
            return reservationDetail;
        }

        public async Task<List<ReservationInScheduleResponseDTO>> GetReservationsInClubByDayAsync(int idTennisClub, DateTime dateOfReservation)
        {
           var reservations = await _context.TennisCourts.Where(t => t.IdTennisClub == idTennisClub).Select(r => new
            {
                IdTennisCourt = r.IdTennisCourt,
                Reservations = r.Reservations.Where(r => r.ReservationDate == dateOfReservation && r.IdState != 3).Select(rs => new
                {
                    StartReservation = rs.StartReservation,
                    EndReservation = rs.EndReservation
                }).ToList()
            }).ToListAsync();
            var reservationsResult = new List<ReservationInScheduleResponseDTO>();
            foreach(var court in reservations)
            {
                var startReservationsHours = new List<string>();
                foreach(var r in court.Reservations)
                {
                    var hoursDiff = (r.EndReservation - r.StartReservation).TotalHours;
                    for (int i = 0; i < hoursDiff; i++)
                    {
                        var hourOf = r.StartReservation.Add(new TimeSpan(i, 0, 0));
                        startReservationsHours.Add(string.Format("{0}:{1:00}", hourOf.Hours, hourOf.Minutes));
                    }    
                }
                reservationsResult.Add(new ReservationInScheduleResponseDTO
                {
                    IdTennisCourt = court.IdTennisCourt,
                    ReservationHours = startReservationsHours
                });
            }
            return reservationsResult;
        }

        public async Task<ReservationStatus> AddReservationsAsync(ReservationRequestDTO reservationDto, int? idUser, bool isWorker)
        {
            if(idUser != null)
            {
                var amountOfUnPaidReservations = await _context.Reservations.Where(r => r.IdPerson == idUser && r.IdState == 2).ToListAsync();
                if (amountOfUnPaidReservations.Count == 3)
                    return ReservationStatus.ToManyReservations;
            }
            var newReservation = new Reservation {
                IdTennisCourt = reservationDto.IdTennisCourt,
                IdPerson = isWorker ? (reservationDto.IdClient == 0 ? null : reservationDto.IdClient) : idUser,
                ReservationDate = DateTime.ParseExact(reservationDto.ReservationDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                StartReservation = reservationDto.StartReservation,
                EndReservation = reservationDto.StartReservation.Add(new TimeSpan(reservationDto.AmountOfReservation, 0, 0)),
                IdState = 2,
            };

            await _context.AddAsync(newReservation);
            if (!(await _context.SaveChangesAsync() > 0))
                return ReservationStatus.DbError;

            return ReservationStatus.Added;
        }

        public async Task<ReservationStatus> CancelReservationByIdAsync(int idReservation, int? idUser)
        {
            var reservation = await _context.Reservations.SingleOrDefaultAsync(r => r.IdReservation == idReservation && r.IdPerson == idUser);
            if (reservation == null)
                return ReservationStatus.NotExist;
            reservation.IdState = 3;
            if (!(await _context.SaveChangesAsync() > 0))
                return ReservationStatus.DbError;
            return ReservationStatus.Success;
        }

        public async Task<ReservationStatus> AddReservationWithMatchAsync(RegisterMatchRequestDTO registerMatchDto, int? idClub)
        {
            var newReservation = new Reservation
            {
                IdTennisCourt = registerMatchDto.IdTennisCourt,
                ReservationDate = DateTime.ParseExact(registerMatchDto.ReservationDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                StartReservation = registerMatchDto.StartReservation,
                EndReservation = registerMatchDto.StartReservation.Add(new TimeSpan(registerMatchDto.AmountOfReservation, 0, 0)),
                IdState = 1,
                IdPerson = null
            };

            var idTournament = await _context.Matches.Where(m => m.IdMatch == registerMatchDto.IdMatch).Select(m => m.IdTournament).SingleOrDefaultAsync();
            var playersOneIsRegistered = await _context.Registrations.AnyAsync(r => r.IdClient == registerMatchDto.IdPlayerTwo && r.IdTournament == idTournament);
            var playersTwoIsRegistered = await _context.Registrations.AnyAsync(r => r.IdClient == registerMatchDto.IdPlayerOne && r.IdTournament == idTournament);
            if (!playersOneIsRegistered || !playersTwoIsRegistered)
                return ReservationStatus.NotExist;
            await _context.AddAsync(newReservation);
            if (!(await _context.SaveChangesAsync() > 0))
                return ReservationStatus.DbError;
            var match = await _context.Matches.SingleOrDefaultAsync(m => m.IdMatch == registerMatchDto.IdMatch);

            match.IdClientOne = registerMatchDto.IdPlayerOne;
            match.IdClientTwo = registerMatchDto.IdPlayerTwo;
            match.IdReservation = newReservation.IdReservation;

            if (!(await _context.SaveChangesAsync() > 0))
                return ReservationStatus.DbError;
            return ReservationStatus.Added;
        }
    }
}
