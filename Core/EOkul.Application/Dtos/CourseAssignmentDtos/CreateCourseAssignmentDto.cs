namespace EOkul.Application.Dtos.CourseAssignmentDtos
{
    public class CreateCourseAssignmentDto
    {
        public int CourseId { get; set; }
        public int ClassroomId { get; set; }
        public int TeacherId { get; set; }
    }
}
