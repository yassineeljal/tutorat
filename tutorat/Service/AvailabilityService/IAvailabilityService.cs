using data.Model;
using System;
using System.Collections.Generic;

namespace tutorat.Service.AvailabilityService
{
    public interface IAvailabilityService
    {
        void CreateAvailability(Availability availability);
        void UpdateAvailability(Availability availability);
        void DeleteAvailability(int id);
        IEnumerable<Availability> GetAllAvailabilities();
        IEnumerable<Availability> GetAvailabilitiesByStudent(int studentId);
    }
}
