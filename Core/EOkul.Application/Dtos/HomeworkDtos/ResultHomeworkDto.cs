namespace EOkul.Application.Dtos.HomeworkDtos
{
    public class ResultHomeworkDto
    {
        public int HomeworkId { get; set; }
        public string CourseName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
    }
}
