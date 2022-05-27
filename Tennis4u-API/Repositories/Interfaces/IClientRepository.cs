using Tennis4u_API.DTOs.Responses;

namespace Tennis4u_API.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<List<ClientShortDetailsResponseDTO>> GetClientsForReservationAsync();
        Task<ClientProfileNavResponseDTO?> GetClientProfileNavDetailsAsync(int idClient);
        Task<ClientDetailResponseDTO?> GetClientDetailResponseAsync(int idClient);
        Task<List<ClientReservation>> GetClientReservationsAsync(int idClient);
        Task<List<ClientMatchResponseDTO>> GetClientMatchesAsync(int idClient);
    }
}
