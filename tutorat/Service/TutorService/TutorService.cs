using data;
using data.Model;
using Microsoft.EntityFrameworkCore;

namespace tutorat.Service.TutorService
{
    public class TutorService : ITutorService
    {
        private readonly ModelDbContext _db = new ModelDbContext();

        public async Task CreateAsync(Tutor tutor)
        {
            await _db.Tutors.AddAsync(tutor);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int da)
        {
            var tutor = await _db.Tutors
                .Include(t => t.Availabilities)
                .Include(t => t.Meetings)
                .FirstOrDefaultAsync(t => t.Da == da);

            if (tutor != null)
            {
                if (tutor.Meetings != null && tutor.Meetings.Count > 0)
                    _db.Meetings.RemoveRange(tutor.Meetings);

                if (tutor.Availabilities != null && tutor.Availabilities.Count > 0)
                    _db.Availabilities.RemoveRange(tutor.Availabilities);

                _db.Tutors.Remove(tutor);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Tutor>> GetAllAsync()
        {
            return await _db.Tutors.ToListAsync();
        }

        public async Task<Tutor> GetByDaAsync(int da)
        {
            return await _db.Tutors.FirstOrDefaultAsync(t => t.Da == da);
        }

        public async Task UpdateAsync(Tutor tutor)
        {
            var existing = await _db.Tutors.FindAsync(tutor.Id);
            if (existing != null)
            {
                _db.Entry(existing).CurrentValues.SetValues(tutor);
                await _db.SaveChangesAsync();
            }
        }
    }
}
