namespace Tennis4u_API.DTOs.Requests
{
    public class MatchResultRequestDTO
    {
        public int IdWinner { get; set; }
        public string Result { get; set; }
        public int IdMatch { get; set; }
    }
}
