namespace EOkul.Application.Dtos.CourseDtos
{
    public class GetCourseByIdDto
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int WeeklyHours { get; set; }
        public bool IsActive { get; set; }
    }
}
