namespace EOkul.Application.Dtos.CourseDtos
{
    public class UpdateCourseDTO
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int WeeklyHours { get; set; }
        public bool IsActive { get; set; }
    }
}
