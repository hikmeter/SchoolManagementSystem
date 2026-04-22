namespace EOkul.Domain.Entities
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public int CourseAssignmentId { get; set; }
        public CourseAssignment CourseAssignment { get; set; }
        public int DayOfWeek { get; set; }
        public int PeriodNumber { get; set; } //1.ders 2.ders vs
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

    }
}
