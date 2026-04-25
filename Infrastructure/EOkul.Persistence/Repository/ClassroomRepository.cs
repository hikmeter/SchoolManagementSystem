using EOkul.Application.Interfaces;
using EOkul.Domain.Entities;
using EOkul.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EOkul.Persistence.Repository
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly AppDbContext _context;

        public ClassroomRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetStudentsByClassroomIdAsync(int id)
        {
            var values = await _context.Students.Where(x => x.ClassroomId == id).ToListAsync();
            return values;
        }
    }
}
