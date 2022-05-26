namespace Tennis4u_API.DTOs.Requests
{
    public class ReservationRequestDTO
    {
        public int IdTennisCourt { get; set; }
        public string ReservationDate { get; set; }
        public TimeSpan StartReservation { get; set; }
        public int AmountOfReservation { get; set; }
        public int IdClient { get; set; }
    }
}
