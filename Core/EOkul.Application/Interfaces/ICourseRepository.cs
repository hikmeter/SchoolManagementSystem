using EOkul.Domain.Entities;

namespace EOkul.Application.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllActiveCoursesAsync();
    }
}
