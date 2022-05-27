namespace Tennis4u_API.DTOs.Responses
{
    public class TournamentInListResponseDTO
    {
        public int IdTournament { get; set; }
        public string TournamentName { get; set; }
        public int Rank { get; set; }
        public DateTime StartDate { get; set; }
        public int? IdWinner { get; set; }
        public string? WinnerName { get; set; }
        public int IdTennisClub { get; set; }
        public string TennisClubName { get; set; }
        public bool HasReservations { get; set; }
    }
}
