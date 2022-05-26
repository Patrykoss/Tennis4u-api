namespace Tennis4u_API.DTOs.Responses
{
    public class ClientMatchResponseDTO
    {
        public int IdTournament { get; set; }
        public string TournamentName { get; set; }
        public string StageTournament { get; set; }
        public int? OpponentId { get; set; }
        public string OpponentName { get; set; }
        public string ResultMatch { get; set; }
        public string MatchDate { get; set; }
        public bool IsWinner { get; set; }
    }
}
