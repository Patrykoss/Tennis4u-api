namespace Tennis4u_API.Models
{
    public class Match
    {
        public int IdMatch { get; set; }
        public int? IdClientOne { get; set; }
        public int? IdClientTwo { get; set; }
        public int? IdWinner { get; set; }
        public int IdTournament { get; set; }
        public int IdStage { get; set; }
        public int? IdReservation { get; set; }
        public string? Result { get; set; }

        public virtual StageTournament IdStageTournamentNavigation { get; set; }
        public virtual Tournament IdTournamentNavigation { get; set; }
        public virtual Reservation IdReservationNavigation { get; set; }
        public virtual Client IdClientOneNavigation { get; set; }
        public virtual Client IdClientTwoNavigation { get; set; }

    }
}
