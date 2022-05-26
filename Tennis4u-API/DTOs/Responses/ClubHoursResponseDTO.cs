namespace Tennis4u_API.DTOs.Responses
{
    public class ClubHoursResponseDTO
    {
        public List<TennisCourtInScheduleResponseDTO> Courts { get; set; }
        public List<WorkingHourResponseDTO> WorkHours { get; set; }
    }
}
