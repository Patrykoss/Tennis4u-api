namespace Tennis4u_API.DTOs.Responses
{
    public class ReservationDetailsResponseDTO
    {
        public int IdTennisCourt { get; set; }
        public int Number { get; set; }
        public string Roof { get; set; }
        public string Surface { get; set; }
        public bool IsLight { get; set; }
        public decimal Price { get; set; }
        public string ResDate { get; set; }
        public List<string> AvailableHours { get; set; }
    }
}
