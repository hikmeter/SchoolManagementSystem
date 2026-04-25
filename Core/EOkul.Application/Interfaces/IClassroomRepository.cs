using EOkul.Domain.Entities;

namespace EOkul.Application.Interfaces
{
    public interface IClassroomRepository
    {
        Task<List<Student>> GetStudentsByClassroomIdAsync(int id);
    }
}
