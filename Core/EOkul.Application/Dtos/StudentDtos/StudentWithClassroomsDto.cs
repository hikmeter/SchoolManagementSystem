using EOkul.Domain.Entities;

namespace EOkul.Application.Dtos.StudentDtos
{
    public class StudentWithClassroomsDto
    {
        public int StudentId { get; set; }
        public string StudentNumber { get; set; }
        public string ClassroomName { get; set; }
        public string FullName { get; set; }
        public Gender Gender { get; set; }
    }
}
