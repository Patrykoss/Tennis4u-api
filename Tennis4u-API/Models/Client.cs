namespace Tennis4u_API.Models
{
    public class Client : Person
    {
        public Client()
        {
            Registrations = new HashSet<Registration>();
            MatchesOne = new HashSet<Match>();
            MatchesTwo = new HashSet<Match>();
            Reservations = new HashSet<Reservation>();
        }
        public string? Avatar { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public virtual ICollection<Registration> Registrations { get; set; }
        public virtual ICollection<Match> MatchesOne { get; set; }
        public virtual ICollection<Match> MatchesTwo { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
