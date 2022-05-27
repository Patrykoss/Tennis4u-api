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
        Task<TournamentDetailsResponseDTO?> GetTournamentDetailsAsync(int idTournament, int? idUser, bool isClient);
        Task<TournamentStatus> RegisterForTournamentAsync(int idTournament, int? idUser);
        Task<List<PlayerOfTournamentResponseDTO>> GetPlayersOfTournamentAsync(int idTournament);
        Task<List<MatchOfTournamentResponseDTO>> GetMatchesOfTournamentAsync(int idTournament);
        Task<TournamentNavResponseDTO?> GetTournamentNavDetailsAsync(int idTournament);
        Task<Tuple<bool,ReservationMatchResponseDTO>> GetAvailablePlayersForMatchAsync(int idTournament, int idMatch, int? idClub);
        Task<int?> GetIdTournamentAsync(int idMatch);
    }
}
