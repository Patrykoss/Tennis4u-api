namespace Tennis4u_API.DTOs.Responses
{
    public class ReservationInScheduleResponseDTO
    {
        public int IdTennisCourt { get; set; }
        public List<string> ReservationHours { get; set; }

    }
}
