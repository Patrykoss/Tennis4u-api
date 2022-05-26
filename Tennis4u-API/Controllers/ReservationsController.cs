using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Tennis4u_API.DTOs.Requests;
using Tennis4u_API.Helpers;
using Tennis4u_API.Repositories.Interfaces;
using Tennis4u_API.Utils;

namespace Tennis4u_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationsController(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        [Authorize(Roles = "Manager,Worker,Client")]
        [HttpGet("{dateOfReservations}/tennisClub/{idTennisClub}")]
        public async Task<IActionResult> GetReservationsInClubByDay(DateTime dateOfReservations, int idTennisClub)
        {
            return Ok(await _reservationRepository.GetReservationsInClubByDayAsync(idTennisClub, dateOfReservations));
        }

        [Authorize(Roles = "Manager,Worker,Client")]
        [HttpGet("tennisCourt/{idTennisCourt}/time/{timeOfReservation}")]
        public async Task<IActionResult> GetInfoForReservation(int idTennisCourt,[FromQuery] string dateOfReservations, TimeSpan timeOfReservation)
        {
            return Ok(await _reservationRepository.GetInfoForReservationAsync(idTennisCourt, DateTime.ParseExact(dateOfReservations, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture), timeOfReservation));
        }

        [Authorize(Roles = "Manager,Worker,Client")]
        [HttpPost]
        public async Task<IActionResult> AddReservation([FromBody] ReservationRequestDTO ReservationRequestDTO)
        {
            var idUser = JwtTokenExtention.GetIdUser(User);
            if (idUser == null)
                return Unauthorized();
            var isW = JwtTokenExtention.IsWorkerOrManager(User);
            var result = await _reservationRepository.AddReservationsAsync(ReservationRequestDTO, idUser, isW);
            if (result == ReservationStatus.DbError)
                return StatusCode((int)HttpStatusCode.InternalServerError, "Błąd serwera");
            return NoContent();
        }


    }
}
