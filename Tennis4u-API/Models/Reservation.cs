namespace Tennis4u_API.Models
{
    public class Reservation
    {
        public int IdReservation { get; set; }
        public int IdTennisCourt { get; set; }
        public int? IdPerson { get; set; }
        public DateTime ReservationDate { get; set; }
        public TimeSpan StartReservation { get; set; }
        public TimeSpan EndReservation { get; set; }
        public int IdState { get; set; }

        public virtual State IdStateNavigation { get; set; }
        public virtual TennisCourt IdTennisCourtNavigation { get; set; }
        public virtual Client IdClientNavigation { get; set; }
        public virtual Match IdMatchNavigation { get; set; }
    }
}
