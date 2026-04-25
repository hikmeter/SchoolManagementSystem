using EOkul.Domain.Entities;

namespace EOkul.Application.Dtos.StudentDtos
{
    public class GetStudentWithClassroomByIdDto
    {
        public int StudentId { get; set; }
        public string StudentNumber { get; set; }
        public string ClassroomName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
    }
}
