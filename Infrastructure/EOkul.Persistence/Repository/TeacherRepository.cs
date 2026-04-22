using EOkul.Application.Interfaces;
using EOkul.Domain.Entities;
using EOkul.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EOkul.Persistence.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly AppDbContext _context;

        public TeacherRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Teacher>> GetAllTeachersWithClassroomsAndCoursesCount()
        {
            return await _context.Teachers.Include(x => x.Classrooms).Include(y => y.CourseAssignments).ToListAsync();
        }
    }
}
