namespace Tennis4u_API.Models
{
    public abstract class Person
    {
        public int IdPerson { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; }
        public string RefreshTokenExp { get; set; }

    }
}
