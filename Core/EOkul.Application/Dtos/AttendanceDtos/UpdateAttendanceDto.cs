namespace EOkul.Application.Dtos.AttendanceDtos
{
    public class UpdateAttendanceDto
    {
        public int AttendanceId { get; set; }
        public int StudentId { get; set; }
        public int CourseAssignmentId { get; set; }
        public DateOnly Date { get; set; }
        public string Note { get; set; }
    }
}
