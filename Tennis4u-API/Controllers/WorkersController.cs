using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Tennis4u_API.DTOs.Requests;
using Tennis4u_API.Helpers;
using Tennis4u_API.Repositories.Interfaces;
using Tennis4u_API.Services.Interfaces;
using Tennis4u_API.Utils;

namespace Tennis4u_API.Controllers
{
    [Authorize(Roles = "Manager")]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly IWorkerRepository _workerRepository;

        public WorkersController(IWorkerRepository workerRepository)
        {
            _workerRepository = workerRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] WorkerCreateRequestDTO registerDTO)
        {
            var result = await _workerRepository.CreateWorkerAsync(registerDTO, JwtTokenExtention.GetIdClub(User).Value);
            return result switch
            {
                UserStatus.EmailNotAvailable => BadRequest("Email jest zajęty"),
                UserStatus.DbError => StatusCode((int)HttpStatusCode.InternalServerError, "Błąd serwera"),
                UserStatus.UserAdded => NoContent(),
                _ => throw new ArgumentOutOfRangeException(),
            };
        }
    }
}
