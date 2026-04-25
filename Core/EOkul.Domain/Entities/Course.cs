namespace EOkul.Domain.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int WeeklyHours { get; set; }
        public CourseType CourseType { get; set; }
        public bool IsActive { get; set; }
        public ICollection<CourseAssignment> CourseAssignments { get; set; }
    }

    public enum CourseType
    {
        Required = 1,
        Elective = 2
    }
}
