using Microsoft.EntityFrameworkCore;
using Tennis4u_API.Data;
using Tennis4u_API.DTOs.Responses;
using Tennis4u_API.Repositories.Interfaces;

namespace Tennis4u_API.Repositories.Implementations
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClientForReservationResponseDTO>> GetClientsForReservationAsync()
        {
            return await _context.Clients.Select(c => new ClientForReservationResponseDTO
            {
                IdClient = c.IdPerson,
                Name = c.FirstName + " " + c.LastName,
            }).ToListAsync();
        }
    }
}
