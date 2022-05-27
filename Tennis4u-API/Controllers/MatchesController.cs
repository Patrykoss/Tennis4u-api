using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Tennis4u_API.DTOs.Requests;
using Tennis4u_API.Repositories.Interfaces;
using Tennis4u_API.Utils;

namespace Tennis4u_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchesController : ControllerBase
    {
        private readonly IMatchRepository _matchRepository;

        public MatchesController(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        [Authorize(Roles = "Worker,Manager")]
        [HttpGet("{idMatch}")]
        public async Task<IActionResult> GetDetailsOfMatch(int idMatch)
        {
            var result = await _matchRepository.GetMatchDetailsAsync(idMatch);
            if (result == null)
                return NotFound("");
            return Ok(result);
        }

        [Authorize(Roles = "Worker,Manager")]
        [HttpPut]
        public async Task<IActionResult> UpdateResult([FromBody] MatchResultRequestDTO matchResultDto)
        {
            var result = await _matchRepository.UpdateResult(matchResultDto);
            if (result == MatchStatus.NotExist)
                return NotFound("Nie znaleziono");
            if (result == MatchStatus.DbError)
                return StatusCode((int)HttpStatusCode.InternalServerError, "Server error");
            return NoContent();
        }


        }
    }
