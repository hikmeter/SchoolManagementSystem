namespace EOkul.Domain.Entities
{
    public class Grade
    {
        public int GradeId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseAssignmentId { get; set; }
        public CourseAssignment CourseAssignment { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public int Score { get; set; }
        public DateTime ExamDate { get; set; }
    }
}
