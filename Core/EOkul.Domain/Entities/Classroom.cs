namespace EOkul.Domain.Entities
{
    public class Classroom
    {
        public int ClassroomId { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public int Capacity { get; set; }
        public ICollection<Student> Students { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }
}
