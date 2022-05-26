using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tennis4u_API.Repositories.Interfaces;

namespace Tennis4u_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TennisClubsController : ControllerBase
    {
        private readonly ITennisClubRepository _tennisClubRepository;

        public TennisClubsController(ITennisClubRepository tennisClubRepository)
        {
            _tennisClubRepository = tennisClubRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTennisClubs()
        {
            return Ok(await _tennisClubRepository.GetTennisClubsAsync());
        }

        [HttpGet("{idTennisClub}")]
        public async Task<IActionResult> GetTennisClub(int idTennisClub)
        {
            var tennisClub = await _tennisClubRepository.GetTennisClubInfoAsync(idTennisClub);
            if (tennisClub == null)
                return NotFound("Nie znaleziono klubu");
            return Ok(tennisClub);
        }

        [Authorize(Roles = "Manager,Worker,Client")]
        [HttpGet("{idTennisClub}/workingHours/{date}")]
        public async Task<IActionResult> GetWorkingHours(int idTennisClub, DateTime date)
        {
            var result = await _tennisClubRepository.GetWorkingHoursByDayAsync(idTennisClub, date);
            if (result == null)
                return NotFound("Klub jest wtedy zamknięty");
            return Ok(result);
        }

        
    }
}
