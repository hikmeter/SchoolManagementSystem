namespace EOkul.Application.Dtos.GradeDtos
{
    public class CreateGradeDto
    {
        public int StudentId { get; set; }
        public int CourseAssignmentId { get; set; }
        public int ExamId { get; set; }
        public int Score { get; set; }
        public DateTime ExamDate { get; set; }
    }
}
