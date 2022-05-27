namespace Tennis4u_API.DTOs.Responses
{
    public class TournamentDetailsResponseDTO
    {
        public int IdTennisClub { get; set; }
        public int IdTournament { get; set; }
        public string TournamentName { get; set; }
        public int Rank { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime EndDateOfRegistration { get; set; }
        public string NumberOfPlayers { get; set; }
        public bool CanPlay { get; set; }

    }
}
