namespace Tennis4u_API.Models
{
    public abstract class TennisCourt
    {
        public TennisCourt()
        {
            Reservations = new HashSet<Reservation>();
        }
        public int IdTennisCourt { get; set; }
        public int Number { get; set; }
        public decimal Price { get; set; }
        public bool IsLight { get; set; }
        public int IdSurface { get; set; }
        public int IdRoof { get; set; }
        public int IdTennisClub { get; set; }

        public virtual TennisClub IdTennisClubNavigation { get; set; }
        public virtual Roof IdRoofNavigation { get; set; }
        public virtual Surface IdSurfaceNavigation { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }

    }
}
