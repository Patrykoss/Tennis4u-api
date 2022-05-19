namespace Tennis4u_API.Models
{
    public class StageTournament
    {
        public StageTournament()
        {
            Matches = new HashSet<Match>();
        }
        public int IdStageTournament { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
    }
}
