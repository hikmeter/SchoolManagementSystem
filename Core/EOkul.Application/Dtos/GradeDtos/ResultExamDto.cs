namespace EOkul.Application.Dtos.GradeDtos
{
    public class ResultExamDto
    {
        public int GradeId { get; set; }
        public string StudentName { get; set; }
        public string CourseName { get; set; }
        public string ExamName { get; set; }
        public int Score { get; set; }
        public DateTime ExamDate { get; set; }
    }
}
