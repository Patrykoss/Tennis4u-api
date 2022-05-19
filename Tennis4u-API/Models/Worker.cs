namespace Tennis4u_API.Models
{
    public class Worker : Person
    {
        public int IdTennisClub { get; set; }
        public int IdRole { get; set; }

        public virtual TennisClub IdTennisClubNavigation { get; set; }
        public virtual Role IdRoleNavigation { get; set; }
    }
}
