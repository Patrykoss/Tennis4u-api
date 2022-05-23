namespace Tennis4u_API.DTOs.Responses
{
    public class TennisClubResponseDTO
    {
        public int IdTennisClub { get; set; }
        public string ClubName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string? PostCode { get; set; }
        public List<string>? PhoneNumbers { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public List<WorkDayResponseDTO>? WorkDays { get; set; }
        public string Logo { get; set; }
    }
}
