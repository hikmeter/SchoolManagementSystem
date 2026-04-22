namespace EOkul.Application.Dtos.CourseAssignmentDtos
{
    public class UpdateCourseAssignmentDto
    {
        public int CourseAssignmentId { get; set; }
        public int CourseId { get; set; }
        public int ClassroomId { get; set; }
        public int TeacherId { get; set; }
    }
}
