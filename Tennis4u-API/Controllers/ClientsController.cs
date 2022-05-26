using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tennis4u_API.Helpers;
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

        [Authorize(Roles = "Manager,Worker,Client")]
        [HttpGet("{idClient}/nav")]
        public async Task<IActionResult> GetClientNavDetails(int idClient)
        {
            var client = await _clientRepository.GetClientProfileNavDetailsAsync(idClient);
            if (client == null)
                return NotFound();
            return Ok(client);
        }

        [Authorize(Roles = "Manager,Worker,Client")]
        [HttpGet("{idClient}")]
        public async Task<IActionResult> GetClientDetails(int idClient)
        {
            var client = await _clientRepository.GetClientDetailResponseAsync(idClient);
            if (client == null)
                return NotFound();
            return Ok(client);
        }

        [Authorize(Roles = "Client")]
        [HttpGet("{idClient}/reservations")]
        public async Task<IActionResult> GetClientReservations(int idClient)
        {
            var idUser = JwtTokenExtention.GetIdUser(User);
            if (idUser != idClient)
                return Forbid();
            var res = await _clientRepository.GetClientReservationsAsync(idClient);
            return Ok(res);
        }

        [Authorize(Roles = "Manager,Worker,Client")]
        [HttpGet("{idClient}/matches")]
        public async Task<IActionResult> GetClientMatches(int idClient)
        {
            var res = await _clientRepository.GetClientMatchesAsync(idClient);
            return Ok(res);
        }

    }
}
