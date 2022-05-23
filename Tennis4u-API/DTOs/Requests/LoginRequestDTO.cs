using System.ComponentModel.DataAnnotations;

namespace Tennis4u_API.DTOs.Requests
{
    public class LoginRequestDTO
    {
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
