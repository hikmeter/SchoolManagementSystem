namespace EOkul.Domain.Entities
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string TCNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Classroom> Classrooms { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}
