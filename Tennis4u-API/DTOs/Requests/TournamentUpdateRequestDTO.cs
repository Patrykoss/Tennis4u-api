namespace Tennis4u_API.DTOs.Requests
{
    public class TournamentUpdateRequestDTO
    {
        public int IdTournament { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MaxPlayers { get; set; }
        public DateTime FinalDateForRegistration { get; set; }
    }
}
