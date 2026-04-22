namespace EOkul.Domain.Entities
{
    public class Attendance
    {
        public int AttendanceId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseAssignmentId { get; set; }
        public CourseAssignment CourseAssignment { get; set; }
        public DateOnly Date { get; set; }
        public string Note { get; set; }
    }
}
