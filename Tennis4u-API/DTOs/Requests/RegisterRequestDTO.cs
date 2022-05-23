using System.ComponentModel.DataAnnotations;

namespace Tennis4u_API.DTOs.Requests
{
    public class RegisterRequestDTO
    {
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [RegularExpression("[0-9]{9}")]
        [MinLength(9)]
        public string PhoneNumber { get; set; }
        public string Avatar { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
