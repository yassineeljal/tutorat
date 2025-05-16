using data;
using data.Model;
using Microsoft.EntityFrameworkCore;

namespace tutorat.Service.TutorService
{
    public class TutorService : ITutorService
    {
        private ModelDbContext _db = new ModelDbContext();
        public void Create(Tutor tutor)
        {
            _db.Tutors.Add(tutor);
            _db.SaveChanges();
        }

        public void Delete(int da)
        {
            var tutor = _db.Tutors.Include(t => t.Availabilities).Include(t => t.Meetings).FirstOrDefault(t => t.Da == da);

            if (tutor != null)
            {
                if (tutor.Meetings != null && tutor.Meetings.Count > 0)
                    _db.Meetings.RemoveRange(tutor.Meetings);

                if (tutor.Availabilities != null && tutor.Availabilities.Count > 0)
                    _db.Availabilities.RemoveRange(tutor.Availabilities);

                _db.Tutors.Remove(tutor);
                _db.SaveChanges();
            }
        }


        public IEnumerable<Tutor> GetAll()
        {
            return _db.Tutors.ToList();
        }

        public Tutor GetByDa(int da)
        {
            var tutor = from t in _db.Tutors
                        where t.Da == da
                        select t;
            return tutor.FirstOrDefault();
        }

        public void Update(Tutor tutor)
        {
            _db.Tutors.Update(tutor);
            _db.SaveChanges();
        }
    }
}
