using data.Model;
using System;
using System.Collections.Generic;

namespace tutorat.Service.AvailabilityService
{
    public interface IAvailabilityService
    {
        Task CreateAvailabilityAsync(Availability availability);
        Task UpdateAvailabilityAsync(Availability availability);
        Task DeleteAvailabilityAsync(int id);
        Task<IEnumerable<Availability>> GetAllAvailabilitiesAsync();
        Task<IEnumerable<Availability>> GetAvailabilitiesByStudentAsync(int studentId);
    }
}
