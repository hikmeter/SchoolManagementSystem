using EOkul.Domain.Entities;

namespace EOkul.Application.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudentsWithClassroomsAsync();
        Task<Student> GetStudentWithClassroomName(int id);
    }
}
