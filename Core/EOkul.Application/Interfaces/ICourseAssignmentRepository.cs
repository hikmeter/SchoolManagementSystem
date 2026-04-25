using EOkul.Domain.Entities;

namespace EOkul.Application.Interfaces
{
    public interface ICourseAssignmentRepository
    {
        Task<List<CourseAssignment>> GetAllCourseAssignments();
        Task<CourseAssignment> GetCourseAssignmentById(int id);

    }
}
