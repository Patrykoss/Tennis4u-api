using Tennis4u_API.DTOs.Requests;
using Tennis4u_API.DTOs.Responses;
using Tennis4u_API.Utils;

namespace Tennis4u_API.Repositories.Interfaces
{
    public interface IMatchRepository
    {
        Task<MatchResponseDTO?> GetMatchDetailsAsync(int idMatch);
        Task<MatchStatus> UpdateResult(MatchResultRequestDTO matchResultDto);
    }
}
