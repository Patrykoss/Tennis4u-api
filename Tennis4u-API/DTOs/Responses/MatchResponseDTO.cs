namespace Tennis4u_API.DTOs.Responses
{
    public class MatchResponseDTO
    {
        public int IdMatch { get; set; }
        public string PlayerOneName { get; set; }
        public string PlayerTwoName { get; set; }
        public string DateOfMatch { get; set; }
        public string StageName { get; set; }
        public List<ClientShortDetailsResponseDTO> Players { get; set; }
    }
}
