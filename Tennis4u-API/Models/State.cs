namespace Tennis4u_API.Models
{
    public class State
    {
        public State()
        {
            Reservations = new HashSet<Reservation>();
        }
        public int IdState { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
