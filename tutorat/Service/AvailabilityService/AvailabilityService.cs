using data;
using data.Model;
using Microsoft.EntityFrameworkCore;

namespace tutorat.Service.AvailabilityService
{
    public class AvailabilityService : IAvailabilityService
    {
        private readonly ModelDbContext _db = new ModelDbContext();

        public async Task CreateAvailabilityAsync(Availability availability)
        {
            if (availability == null)
            {
                throw new ArgumentNullException(nameof(availability));
            }
            await _db.Availabilities.AddAsync(availability);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAvailabilityAsync(Availability availability)
        {
            if (availability == null)
            {
                throw new ArgumentNullException(nameof(availability));
            }
            var existingAvailability = await _db.Availabilities.FindAsync(availability.Id);
            if (existingAvailability != null)
            {
                existingAvailability.DayOfWeek = availability.DayOfWeek;
                existingAvailability.StartTime = availability.StartTime;
                existingAvailability.EndTime = availability.EndTime;
                existingAvailability.StudentId = availability.StudentId;

                await _db.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"Availability with id {availability.Id} not found.");
            }
        }

        public async Task DeleteAvailabilityAsync(int id)
        {
            var availability = await _db.Availabilities.FindAsync(id);
            if (availability != null)
            {
                _db.Availabilities.Remove(availability);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"Availability with id {id} not found.");
            }
        }

        public async Task<IEnumerable<Availability>> GetAllAvailabilitiesAsync()
        {
            return await _db.Availabilities.ToListAsync();
        }

        public async Task<IEnumerable<Availability>> GetAvailabilitiesByStudentAsync(int studentId)
        {
            return await _db.Availabilities
                             .Where(a => a.StudentId == studentId)
                             .ToListAsync();
        }

    }
}
