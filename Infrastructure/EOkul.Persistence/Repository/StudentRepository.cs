using EOkul.Application.Interfaces;
using EOkul.Domain.Entities;
using EOkul.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EOkul.Persistence.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _context;

        public StudentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllStudentsWithClassroomsAsync()
        {
            return await _context.Students.Include(x => x.Classroom).ToListAsync();
        }

        public async Task<Student> GetStudentByQueryAsync(string query)
        {
            var value = await _context.Students.FirstOrDefaultAsync(x => x.StudentNumber == query || x.TCNumber == query);
            return value;
        }

        public async Task<Student> GetStudentWithClassroomNameAsync(int id)
        {
            return await _context.Students.Include(x => x.Classroom).FirstOrDefaultAsync(x => x.StudentId == id);
        }
    }
}
