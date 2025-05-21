using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data;
using data.Model;
using Microsoft.EntityFrameworkCore;

namespace tutorat.Service.TeacherService
{
    public class TeacherService : ITeacherService
    {
        private readonly ModelDbContext _db = new ModelDbContext();

        public async Task<Teacher> GetByLastNameAsync(string lastname)
        {
            return await _db.Teachers.FirstOrDefaultAsync(t => t.LastName == lastname);
        }

        public async Task CreateAsync(Teacher teacher)
        {
            await _db.Teachers.AddAsync(teacher);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var teacher = await _db.Teachers.FindAsync(id);
            if (teacher != null)
            {
                _db.Teachers.Remove(teacher);
                await _db.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Teacher teacher)
        {
            var existing = await _db.Teachers.FindAsync(teacher.Id);
            if (existing != null)
            {
                _db.Entry(existing).CurrentValues.SetValues(teacher);
                await _db.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Teacher>> GetAllAsync()
        {
            return await _db.Teachers.ToListAsync();
        }
    }
}
