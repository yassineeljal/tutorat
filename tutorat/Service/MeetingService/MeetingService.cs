using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data;
using data.Model;

namespace tutorat.Service.MeetingService
{

    public class MeetingService : IMeetingService
    {
        private ModelDbContext _db = new ModelDbContext();

        public void Create(Meeting meeting)
        {
            _db.Meetings.Add(meeting);
            _db.SaveChanges();
        }
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Meeting> GetAll()
        {
            return _db.Meetings.ToList();
        }
        public Meeting GetById(int id)
        {
            var meeting = from t in _db.Meetings
                        where t.Id == id
                        select t;
            return meeting.FirstOrDefault();
        }
    }
}
