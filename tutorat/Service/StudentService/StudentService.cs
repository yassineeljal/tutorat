using data;
using data.Model;
using Microsoft.EntityFrameworkCore;

namespace tutorat.Service.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly ModelDbContext _db = new ModelDbContext();

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _db.Students
                .Include(s => s.Requests)
                .Include(s => s.Availabilities)
                .Include(s => s.Meetings)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task CreateAsync(Student student)
        {
            await _db.Students.AddAsync(student);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _db.Students.FindAsync(id);
            if (student != null)
            {
                _db.Students.Remove(student);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _db.Students
                .Include(s => s.Requests)
                .ToListAsync();
        }

        public async Task<Student> GetByDaAsync(int Da)
        {
            return await _db.Students.FirstOrDefaultAsync(s => s.Da == Da);
        }

        public async Task UpdateAsync(Student student)
        {
            _db.Students.Update(student);
            await _db.SaveChangesAsync();
        }

    }
}
