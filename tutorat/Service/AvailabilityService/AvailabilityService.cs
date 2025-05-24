using data;
using data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace tutorat.Service.AvailabilityService
{
    public class AvailabilityService : IAvailabilityService
    {
        private ModelDbContext _db = new ModelDbContext();

        public void CreateAvailability(Availability availability)
        {
            if (availability == null)
            {
                throw new ArgumentNullException(nameof(availability));
            }
            _db.Availabilities.Add(availability);
            _db.SaveChanges();
        }

        public void UpdateAvailability(Availability availability)
        {
            if (availability == null)
            {
                throw new ArgumentNullException(nameof(availability));
            }
            var existingAvailability = _db.Availabilities.Find(availability.Id);
            if (existingAvailability != null)
            {
                existingAvailability.DayOfWeek = availability.DayOfWeek;
                existingAvailability.StartTime = availability.StartTime;
                existingAvailability.EndTime = availability.EndTime;
                existingAvailability.StudentId = availability.StudentId;

                _db.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Availability with id {availability.Id} not found.");
            }
        }

        public void DeleteAvailability(int id)
        {
            var availability = _db.Availabilities.Find(id);
            if (availability != null)
            {
                _db.Availabilities.Remove(availability);
                _db.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Availability with id {id} not found.");
            }
        }

        public IEnumerable<Availability> GetAllAvailabilities()
        {
            return _db.Availabilities.ToList();
        }

        public IEnumerable<Availability> GetAvailabilitiesByStudent(int studentId)
        {
            return _db.Availabilities.Where(a => a.StudentId == studentId).ToList();
        }
    }
}
