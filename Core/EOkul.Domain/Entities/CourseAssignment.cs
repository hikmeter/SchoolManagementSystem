namespace EOkul.Domain.Entities
{
    public class CourseAssignment
    {
        public int CourseAssignmentId { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public ICollection<Schedule> Schedules { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<Exam> Exams { get; set; }
        public ICollection<Homework> Homeworks { get; set; }
    }
}
