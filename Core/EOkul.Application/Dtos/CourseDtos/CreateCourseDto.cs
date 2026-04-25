using EOkul.Domain.Entities;

namespace EOkul.Application.Dtos.CourseDtos
{
    public class CreateCourseDto
    {
        public string Name { get; set; }
        public int WeeklyHours { get; set; }
        public CourseType CourseType { get; set; }
        public bool IsActive { get; set; }
    }
}
