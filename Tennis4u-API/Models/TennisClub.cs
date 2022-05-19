namespace Tennis4u_API.Models
{
    public class TennisClub
    {
        public TennisClub()
        {
            WorkDays = new HashSet<WorkDay>();
            Tournaments = new HashSet<Tournament>();
            Workers = new HashSet<Worker>();
            TennisCourts = new HashSet<TennisCourt>();
        }
        public int IdTennisClub { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string PhoneNumbers { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string PostCode { get; set; }
        public string Logo { get; set; }

        public virtual ICollection<WorkDay> WorkDays { get; set; }
        public virtual ICollection<Tournament> Tournaments { get; set; }
        public virtual ICollection<Worker> Workers { get; set; }
        public virtual ICollection<TennisCourt> TennisCourts { get; set; }
    }
}
