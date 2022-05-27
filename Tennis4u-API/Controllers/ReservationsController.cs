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

        [Authorize(Roles = "Client")]
        [HttpPut("{idReservation}")]
        public async Task<IActionResult> CancelReservation(int idReservation)
        {
            var idUser = JwtTokenExtention.GetIdUser(User);
            if (idUser == null)
                return Unauthorized();
            var result = await _reservationRepository.CancelReservationByIdAsync(idReservation, idUser);
            if(result == ReservationStatus.NotExist)
                return NotFound("");
            if (result == ReservationStatus.DbError)
                return StatusCode((int)HttpStatusCode.InternalServerError, "Błąd serwera");
            return NoContent();
        }

        [Authorize(Roles = "Manager,Worker")]
        [HttpPost("match")]
        public async Task<IActionResult> AddReservationWithMatchForTournament([FromBody] RegisterMatchRequestDTO registerMatchDto)
        {
            var idClub = JwtTokenExtention.GetIdClub(User);
            if (idClub == null)
                return Unauthorized();
            var result = await _reservationRepository.AddReservationWithMatchAsync(registerMatchDto, idClub);
            if (result == ReservationStatus.NotExist)
                return BadRequest("");
            if (result == ReservationStatus.DbError)
                return StatusCode((int)HttpStatusCode.InternalServerError, "Błąd serwera");
            return NoContent();
        }

    }
}
