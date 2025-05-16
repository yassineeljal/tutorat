using data;
using data.Model;
using Microsoft.EntityFrameworkCore;

namespace tutorat.Service.StudentService
{
    public class StudentService : IStudentService
    {
        private ModelDbContext _db = new ModelDbContext();

        public void Create(Student student)
        {
            _db.Students.Add(student);
            _db.SaveChanges();

        }

        public void Delete(int id)
        {
            if (_db.Students.Find(id) != null)
            {
                _db.Students.Remove(_db.Students.Find(id));
                _db.SaveChanges();
            }
        }

        public IEnumerable<Student> GetAll()
        {
            return _db.Students.Include(s => s.Requests).ToList();
        }

        public Student GetByDa(int Da)
        {
            var student = _db.Students.FirstOrDefault(s => s.Da == Da);
            if (student == null)
            {
                return null;
            }
            return student;
        }

        public void Update(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
