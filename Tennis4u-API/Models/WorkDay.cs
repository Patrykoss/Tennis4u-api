namespace Tennis4u_API.Models
{
    public class WorkDay
    {
        public int IdWorkDay { get; set; }
        public TimeSpan OpenHour { get; set; }
        public TimeSpan CloseHour { get; set; }
        public int IdDay { get; set; }
        public int IdTennisClub { get; set; }

        public virtual Day IdDayNavigation { get; set; }
        public virtual TennisClub IdTenniClubNavigation { get; set; }
    }
}
