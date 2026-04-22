namespace EOkul.Application.Dtos.CourseAssignmentDtos
{
    public class GetCourseAssignmentByIdDto
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int WeeklyHours { get; set; }
        public bool IsActive { get; set; }
    }
}
