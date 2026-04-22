namespace EOkul.Application.Dtos.ScheduleDtos
{
    public class CreateScheduleDTO
    {
        public int CourseAssignmentId { get; set; }
        public int DayOfWeek { get; set; }
        public int PeriodNumber { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
