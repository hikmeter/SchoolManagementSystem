namespace EOkul.Application.Dtos.TeacherDtos
{
    public class GetTeacherByIdDto
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        //public List<TeacherClassroomDto> Classrooms { get; set; } = new();
        //public List<TeacherCourseDto> Courses { get; set; } = new();
    }
}
