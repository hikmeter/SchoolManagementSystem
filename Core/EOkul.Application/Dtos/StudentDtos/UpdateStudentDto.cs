namespace EOkul.Application.Dtos.StudentDtos
{
    public class UpdateStudentDto
    {
        public int StudentId { get; set; }
        public string StudentNumber { get; set; }
        public int ClassroomId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCNumber { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
