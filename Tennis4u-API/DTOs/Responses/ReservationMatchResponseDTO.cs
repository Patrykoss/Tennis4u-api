namespace Tennis4u_API.DTOs.Responses
{
    public class ReservationMatchResponseDTO
    {
        public string TournamentStageName { get; set; }
        public List<ClientShortDetailsResponseDTO> Players { get; set; }
    }
}
