using data.Model;

namespace tutorat.Service.MeetingService
{
    public interface IMeetingService
    {
        Meeting GetById(int id);
        IEnumerable<Meeting> GetAll();
        void Create(Meeting meeting);
        void Delete(int id);
    }
}
