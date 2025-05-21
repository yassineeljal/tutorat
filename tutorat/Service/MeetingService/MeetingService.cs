using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data;
using data.Model;
using Microsoft.EntityFrameworkCore;

namespace tutorat.Service.MeetingService
{

    public class MeetingService : IMeetingService
    {
        private ModelDbContext _db = new ModelDbContext();

        public async Task CreateAsync(Meeting meeting)
        {
            await _db.Meetings.AddAsync(meeting);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var meeting = await _db.Meetings.FindAsync(id);
            if (meeting != null)
            {
                _db.Meetings.Remove(meeting);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Meeting>> GetAllAsync()
        {
            return await _db.Meetings.ToListAsync();
        }

        public async Task<Meeting> GetByIdAsync(int id)
        {
            return await _db.Meetings.FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
