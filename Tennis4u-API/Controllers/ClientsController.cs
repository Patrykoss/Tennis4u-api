using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tennis4u_API.Repositories.Interfaces;

namespace Tennis4u_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientRepository _clientRepository;

        public ClientsController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        [Authorize(Roles = "Manager,Worker")]
        [HttpGet]
        public async Task<IActionResult> GetClientsForResevation()
        {
            return Ok(await _clientRepository.GetClientsForReservationAsync());
        }

    }
}
