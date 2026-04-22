namespace EOkul.Application.Dtos.TeacherDtos
{
    public class GetAllTeachersWithClassroomsAndCourses
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public int ClassroomCount { get; set; }
        public int CourseCount { get; set; }
    }
}
