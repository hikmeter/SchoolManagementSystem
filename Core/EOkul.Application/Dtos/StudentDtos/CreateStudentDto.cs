using EOkul.Domain.Entities;

namespace EOkul.Application.Dtos.StudentDtos
{
    public class CreateStudentDto
    {
        public string StudentNumber { get; set; }
        public int ClassroomId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCNumber { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
