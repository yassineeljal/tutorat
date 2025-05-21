using data.Model;

namespace tutorat.Service.MeetingService
{
    public interface IMeetingService
    {
        Task<Meeting> GetByIdAsync(int id);
        Task<IEnumerable<Meeting>> GetAllAsync();
        Task CreateAsync(Meeting meeting);
        Task DeleteAsync(int id);
    }
}
