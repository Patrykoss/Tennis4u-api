namespace Tennis4u_API.DTOs.Responses
{
    public class MatchOfTournamentResponseDTO
    {
        public string Stage { get; set; }
        public int? IdClientOne { get; set; }
        public string? NameOne { get; set; }
        public int? IdClientTwo { get; set; }
        public int? IdWinner { get; set; }
        public string? NameTwo { get; set; }
        public string? Result { get; set; }
        public string? DateOfMatch { get; set; }
    }
}
