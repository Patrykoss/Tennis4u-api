namespace Tennis4u_API.DTOs.Responses
{
    public class LoginResponseDTO
    {
        public string Name { get; set; }
        public string? Avatar { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
