namespace Tennis4u_API.Models
{
    public class Tournament
    {
        public Tournament()
        {
            Registrations = new HashSet<Registration>();
            Matches = new HashSet<Match>();
        }
        public int IdTournament { get; set; }
        public string Name { get; set; }
        public int Rank { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int MaxNumberOfPlayers { get; set; }
        public DateTime FinalDateForRegistration { get; set; }
        public int IdTennisClub { get; set; }

        public virtual TennisClub IdTennisClubNavigation { get; set; }
        public ICollection<Registration> Registrations { get; set; }
        public ICollection<Match> Matches { get; set; }
    }
}
