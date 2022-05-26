﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Security.Claims;
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


    }
}