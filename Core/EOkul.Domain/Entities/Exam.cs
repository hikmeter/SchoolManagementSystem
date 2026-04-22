namespace EOkul.Domain.Entities
{
    public class Exam
    {
        public int ExamId { get; set; }
        public string Name { get; set; }
        public int CourseAssingmentId { get; set; }
        public CourseAssignment CourseAssignment { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}
