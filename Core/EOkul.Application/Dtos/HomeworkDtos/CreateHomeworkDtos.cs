namespace EOkul.Application.Dtos.HomeworkDtos
{
    public class CreateHomeworkDtos
    {
        public int CourseAssignmentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }
}
