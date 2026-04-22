namespace EOkul.Application.Dtos.HomeworkDtos
{
    public class GetHomeworkByIdDto
    {
        public int HomeworkId { get; set; }
        public int CourseAssignmentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }
}
