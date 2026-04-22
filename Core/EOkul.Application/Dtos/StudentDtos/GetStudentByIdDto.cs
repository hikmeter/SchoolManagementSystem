namespace EOkul.Application.Dtos.StudentDtos
{
    public class GetStudentByIdDto
    {
        public int StudentId { get; set; }
        public string StudentNumber { get; set; }
        public string ClassroomId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCNumber { get; set; }
        public DateTime BirthDate { get; set; }
        //public List<StudentGradeDto> Grades { get; set; }
        //public List<StudentAttendanceDto> Attendances { get; set; }
    }
}
