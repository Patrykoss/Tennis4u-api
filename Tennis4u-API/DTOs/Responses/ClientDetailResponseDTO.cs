namespace Tennis4u_API.DTOs.Responses
{
    public class ClientDetailResponseDTO
    {
        public int IdClient { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public int NumberOfWonMatches { get; set; }
    }
}
