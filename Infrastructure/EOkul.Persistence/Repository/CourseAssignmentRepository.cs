using EOkul.Application.Interfaces;
using EOkul.Domain.Entities;
using EOkul.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EOkul.Persistence.Repository
{
    public class CourseAssignmentRepository : ICourseAssignmentRepository
    {
        private readonly AppDbContext _context;

        public CourseAssignmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CourseAssignment>> GetAllCourseAssignments()
        {
            var values = await _context.CourseAssignments.Include(x => x.Course).Include(y => y.Teacher).Include(z => z.Classroom).ToListAsync();
            return values;
        }

        public async Task<CourseAssignment> GetCourseAssignmentById(int id)
        {
            var value = await _context.CourseAssignments.Include(x => x.Course).Include(y => y.Teacher).Include(z => z.Classroom).FirstOrDefaultAsync(y => y.CourseAssignmentId == id);
            return value;
        }
    }
}
