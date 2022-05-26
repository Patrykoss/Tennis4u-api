using Tennis4u_API.DTOs.Requests;
using Tennis4u_API.DTOs.Responses;
using Tennis4u_API.Utils;

namespace Tennis4u_API.Repositories.Interfaces
{
    public interface IReservationRepository
    {
        Task<List<ReservationInScheduleResponseDTO>> GetReservationsInClubByDayAsync(int idTennisClub, DateTime dateOfReservation);
        Task<ReservationDetailsResponseDTO> GetInfoForReservationAsync(int idTennisCourt, DateTime dateReservation, TimeSpan timeReservation);
        Task<ReservationStatus> AddReservationsAsync(ReservationRequestDTO reservationDto, int? idUser, bool isWorker);
    }
}
