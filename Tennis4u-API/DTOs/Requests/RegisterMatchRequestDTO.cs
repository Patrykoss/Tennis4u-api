namespace Tennis4u_API.DTOs.Requests
{
    public class RegisterMatchRequestDTO
    {
        public int IdMatch { get; set; }
        public int IdPlayerOne { get; set; }
        public int IdPlayerTwo { get; set; }
        public int IdTennisCourt { get; set; }
        public string ReservationDate { get; set; }
        public TimeSpan StartReservation { get; set; }
        public int AmountOfReservation { get; set; }
    }
}
