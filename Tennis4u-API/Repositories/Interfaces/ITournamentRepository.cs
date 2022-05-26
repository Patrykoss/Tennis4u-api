using Tennis4u_API.DTOs.Responses;
using Tennis4u_API.Utils;

namespace Tennis4u_API.Repositories.Interfaces
{
    public interface ITournamentRepository
    {
        Task<List<TournamentInListResponseDTO>> GetTournamentsAsync();
        Task<List<TournamentInListResponseDTO>> GetClubTournamentsAsync(int idTennisClub);
        Task<TournamentStatus> DeleteTournamentByIdAsync(int idTournament);
        Task<bool> IsWorkerManageOfTournament(int? idWorker, int idTournament);
    }
}
