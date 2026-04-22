namespace EOkul.Application.Dtos.ScheduleDtos
{
    public class ResultScheduleDto
    {
        public int ScheduleId { get; set; }
        public string CourseName { get; set; }
        public int DayOfWeek { get; set; }
        public int PeriodNumber { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
