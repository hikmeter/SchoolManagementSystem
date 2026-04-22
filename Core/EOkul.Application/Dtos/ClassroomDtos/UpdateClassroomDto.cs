namespace EOkul.Application.Dtos.ClassroomDtos
{
    public class UpdateClassroomDto
    {
        public int ClassroomId { get; set; }
        public string Name { get; set; }
        public int Grade { get; set; }
        public int TeacherId { get; set; }
        public int Capacity { get; set; }
    }
}
