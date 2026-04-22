namespace EOkul.Application.Dtos.TeacherDtos
{
    public class UpdateTeacherDto
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
    }
}
