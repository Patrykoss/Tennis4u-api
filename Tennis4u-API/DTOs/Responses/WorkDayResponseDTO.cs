﻿namespace Tennis4u_API.DTOs.Responses
{
    public class WorkDayResponseDTO
    {
        public string DayName { get; set; }
        public TimeSpan OpenHour { get; set; }
        public TimeSpan CloseHour { get; set; }
    }
}
