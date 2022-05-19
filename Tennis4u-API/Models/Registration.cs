namespace Tennis4u_API.Models
{
    public class Registration
    {
        public int IdClient { get; set; }
        public int IdTournament { get; set; }

        public virtual Tournament IdTournamentNavigation { get; set; }
        public virtual Client IdClientNavigation { get; set; }
    }
}
