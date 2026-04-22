namespace EOkul.Domain.Entities
{
    public class Homework
    {
        public int HomeworkId { get; set; }
        public int CourseAssignmentId { get; set; }
        public CourseAssignment CourseAssignment { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }
}
