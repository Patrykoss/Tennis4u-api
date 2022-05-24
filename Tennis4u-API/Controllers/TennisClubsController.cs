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
    }
}
