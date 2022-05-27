namespace Tennis4u_API.DTOs.Responses
{
    public class TournamentStageResponseDTO
    {
        public List<ClientShortDetailsResponseDTO> Players { get; set; }
        public string StageName { get; set; }
    }
}
