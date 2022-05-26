namespace Tennis4u_API.DTOs.Responses
{
    public class ClientReservation
    {
        public int IdReservation { get; set; }
        public int IdTennisClub { get; set; }
        public string TennisClubName { get; set; }
        public string ReservationRange { get; set; }
        public int CourtNumber { get; set; }
        public double Price { get; set; }
        public bool IsAvailableToCancel { get; set; }
        public string Status { get; set; }
    }
}
