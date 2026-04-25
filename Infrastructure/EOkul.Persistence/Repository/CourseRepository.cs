using EOkul.Application.Interfaces;
using EOkul.Domain.Entities;
using EOkul.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EOkul.Persistence.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetAllActiveCoursesAsync()
        {
            var values = await _context.Courses.Where(x => x.IsActive == true).ToListAsync();
            return values;
        }
    }
}
