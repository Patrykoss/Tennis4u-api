using Tennis4u_API.DTOs.Responses;

namespace Tennis4u_API.Repositories.Interfaces
{
    public interface ITennisClubRepository
    {
        Task<List<TennisClubResponseDTO>> GetTennisClubsAsync();

        Task<TennisClubResponseDTO?> GetTennisClubInfoAsync(int idTennisClub);
    }
}
