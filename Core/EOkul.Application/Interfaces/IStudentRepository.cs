using EOkul.Domain.Entities;

namespace EOkul.Application.Interfaces
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudentsWithClassroomsAsync();
        Task<Student> GetStudentWithClassroomNameAsync(int id);
        Task<Student> GetStudentByQueryAsync(string query);
    }
}
