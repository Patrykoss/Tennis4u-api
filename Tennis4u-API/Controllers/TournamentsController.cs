using Microsoft.AspNetCore.Mvc;
using Tennis4u_API.Repositories.Interfaces;

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
    }
}
