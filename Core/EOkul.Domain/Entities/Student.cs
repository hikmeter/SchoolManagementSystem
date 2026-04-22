namespace EOkul.Domain.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentNumber { get; set; }
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
    }
}
