using Tennis4u_API.DTOs.Responses;

namespace Tennis4u_API.Repositories.Interfaces
{
    public interface ITournamentRepository
    {
        Task<List<TournamentInListResponseDTO>> GetTournamentsAsync();
    }
}
