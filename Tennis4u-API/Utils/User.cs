namespace Tennis4u_API.Utils
{
    public class User
    {
        public int IdPerson { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Avatar { get; set; }
        public string? RoleInClubName { get; set; }
        public bool IsClient { get; set; }
        public int? IdClub { get; set; }
    }
}
