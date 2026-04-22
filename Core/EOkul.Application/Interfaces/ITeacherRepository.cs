using EOkul.Domain.Entities;

namespace EOkul.Application.Interfaces
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> GetAllTeachersWithClassroomsAndCoursesCount();
    }
}
