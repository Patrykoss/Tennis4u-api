namespace Tennis4u_API.DTOs.Responses
{
    public class MatchOfTournamentResponseDTO
    {
        public int IdTennisClub { get; set; }
        public int IdMatch { get; set; }
        public string Stage { get; set; }
        public int? IdClientOne { get; set; }
        public string? NameOne { get; set; }
        public int? IdClientTwo { get; set; }
        public int? IdWinner { get; set; }
        public string? NameTwo { get; set; }
        public string? Result { get; set; }
        public string? DateOfMatch { get; set; }
        public DateTime DateOfStart { get; set; }
    }
}
