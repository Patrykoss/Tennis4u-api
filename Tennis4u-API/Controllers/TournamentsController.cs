using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
using Tennis4u_API.DTOs.Requests;
using Tennis4u_API.Helpers;
using Tennis4u_API.Repositories.Interfaces;
using Tennis4u_API.Utils;

namespace Tennis4u_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentsController : ControllerBase
    {
        private readonly ITournamentRepository _tournamentsRepository;

        public TournamentsController(ITournamentRepository tournamentsRepository)
        {
            _tournamentsRepository = tournamentsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTournaments()
        {
            return Ok(await _tournamentsRepository.GetTournamentsAsync());
        }

        [HttpGet("tennisClub/{idTennisClub}")]
        public async Task<IActionResult> GetClubTournaments(int idTennisClub)
        {
            return Ok(await _tournamentsRepository.GetClubTournamentsAsync(idTennisClub));
        }

        [Authorize(Roles = "Manager,Worker")]
        [HttpDelete("{idTennisClub}")]
        public async Task<IActionResult> DeleteTournament(int idTennisClub)
        {
            var idUser = JwtTokenExtention.GetIdUser(User);
            if(idUser == null)
                return Unauthorized();
            var hasWarrant = await _tournamentsRepository.IsWorkerManageOfTournament(idUser, idTennisClub);
            if (!hasWarrant)
                return StatusCode((int)HttpStatusCode.Forbidden, "Nie wystarczające uprawnienia do turnieju");
            var result = await _tournamentsRepository.DeleteTournamentByIdAsync(idTennisClub);
            return result switch
            {
                TournamentStatus.TournamentNotExist => BadRequest(),
                TournamentStatus.DbError => StatusCode((int)HttpStatusCode.InternalServerError),
                TournamentStatus.TournamentDeleted => NoContent(),
                _ => throw new ArgumentOutOfRangeException(),
            };
        }

        [Authorize(Roles = "Manager,Worker,Client")]
        [HttpGet("{idTournament}")]
        public async Task<IActionResult> GetTournament(int idTournament)
        {
            var idUser = JwtTokenExtention.GetIdUser(User);
            if (idUser == null)
                return Unauthorized();
            var result = await _tournamentsRepository.GetTournamentDetailsAsync(idTournament, idUser, JwtTokenExtention.IsClient(User));
            if (result == null)
                return NotFound("Turniej nie istnieje");
            return Ok(result);
        }

        [Authorize(Roles = "Client")]
        [HttpPost("{idTournament}/registration")]
        public async Task<IActionResult> RegisterForTournament(int idTournament)
        {
            var idUser = JwtTokenExtention.GetIdUser(User);
            if (idUser == null)
                return Unauthorized();
            var result = await _tournamentsRepository.RegisterForTournamentAsync(idTournament, idUser);
            if (result == TournamentStatus.DbError)
                return StatusCode((int)HttpStatusCode.InternalServerError,"DbError");
            return NoContent();
        }

        [Authorize(Roles = "Manager,Worker,Client")]
        [HttpGet("{idTournament}/players")]
        public async Task<IActionResult> GetPlayersOfTournaments(int idTournament)
        {
            return Ok(await _tournamentsRepository.GetPlayersOfTournamentAsync(idTournament));
        }

        [Authorize(Roles = "Manager,Worker,Client")]
        [HttpGet("{idTournament}/matches")]
        public async Task<IActionResult> GetMatchesOfTournaments(int idTournament)
        {
            return Ok(await _tournamentsRepository.GetMatchesOfTournamentAsync(idTournament));
        }


        [Authorize(Roles = "Manager,Worker,Client")]
        [HttpGet("{idTournament}/nav")]
        public async Task<IActionResult> GetTournamentNav(int idTournament)
        {
            var result = await _tournamentsRepository.GetTournamentNavDetailsAsync(idTournament);
            if (result == null)
                return NotFound("");
            return Ok(result);
        }

        [Authorize(Roles = "Manager,Worker")]
        [HttpGet("{idMatch}/matchPlayers")]
        public async Task<IActionResult> GetRegisteredPlayers(int idMatch)
        {
            var idClub = JwtTokenExtention.GetIdClub(User);
            if (idClub == null)
                return Unauthorized();
            var idTournament = await _tournamentsRepository.GetIdTournamentAsync(idMatch);
            var result = await _tournamentsRepository.GetAvailablePlayersForMatchAsync(idTournament.Value, idMatch, idClub);
            if (!result.Item1)
                return StatusCode((int)HttpStatusCode.Forbidden, "Nie upoważniony dostęp");
            return Ok(result.Item2);
        }

        [Authorize(Roles = "Manager,Worker")]
        [HttpPost]
        public async Task<IActionResult> CreateTournament([FromBody]CreateTournamentRequestDTO createTournamentRequestDTO)
        {
            var idClub = JwtTokenExtention.GetIdClub(User);
            if (idClub == null)
                return Unauthorized();
            var result = await _tournamentsRepository.CreateTournamentAsync(createTournamentRequestDTO, idClub.Value);
            if (result.Item1 == TournamentStatus.DbError)
                return StatusCode((int)HttpStatusCode.Forbidden, "Błąd serwera");
            var res = await _tournamentsRepository.AssignMatches(result.Item2);
            if(!res)
                return StatusCode((int)HttpStatusCode.Forbidden, "Błąd serwera");
            return NoContent();
        }

        [Authorize(Roles = "Manager,Worker")]
        [HttpPut]
        public async Task<IActionResult> UpdateTournament([FromBody] TournamentUpdateRequestDTO tournamentRequestDTO)
        {
            var result = await _tournamentsRepository.UpdateTournamentAsync(tournamentRequestDTO);
            if (result == TournamentStatus.TournamentNotExist)
                return NotFound("Nie istnieje turniej");
            if (result == TournamentStatus.DbError)
                return StatusCode((int)HttpStatusCode.Forbidden, "Błąd serwera");
            return NoContent();
        }

    }
}
