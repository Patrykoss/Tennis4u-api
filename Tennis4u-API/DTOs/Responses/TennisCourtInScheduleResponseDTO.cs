namespace Tennis4u_API.DTOs.Responses
{
    public class TennisCourtInScheduleResponseDTO
    {
        public int IdTennisCourt { get; set; }
        public int Number { get; set; }
        public int IdTennisClub { get; set; }
        public string Roof { get; set; }
        public string Surface { get; set; }
    }
}
