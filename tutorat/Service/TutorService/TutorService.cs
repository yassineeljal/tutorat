using data;
using data.Model;

namespace tutorat.Service.TutorService
{
    public class TutorService : ITutorService
    {
        private TutorDbContext _db = new TutorDbContext();
        public void Create(Tutor tutor)
        {
            _db.Tutors.Add(tutor);
            _db.SaveChanges();
        }

        public void Delete(int da)
        {
            if (_db.Tutors.Find(da) != null) {
                _db.Tutors.Remove(_db.Tutors.Find(da));
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
            var exist = _db.Tutors.FirstOrDefault(t => t.Da == tutor.Da);
            if (exist != null){
                
            }
            _db.SaveChanges();
        }
    }
}
