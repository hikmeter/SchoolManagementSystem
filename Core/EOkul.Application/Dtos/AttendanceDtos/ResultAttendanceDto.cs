namespace EOkul.Application.Dtos.AttendanceDtos
{
    public class ResultAttendanceDto
    {
        public int AttendanceId { get; set; }
        public string StudentName { get; set; }
        public string CourseName { get; set; }
        public DateOnly Date { get; set; }
        public string Note { get; set; }
    }
}
