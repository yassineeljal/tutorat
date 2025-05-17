using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data;
using data.Model;

namespace tutorat.Service.TeacherService
{
    public class TeacherService : ITeacherService
    {
        private ModelDbContext _db;

        public void Create(Teacher teacher)
        {
            _db.Teachers.Add(teacher);
            _db.SaveChanges();
            
        }

        public void Delete(int id)
        {
            if(_db.Teachers.Find(id) != null)
            {
                _db.Teachers.Remove(_db.Teachers.Find(id));
            }
        }

        public void Update(Teacher teacher)
        {
            if (_db.Teachers.Find(teacher.Id) != null)
            {

            }
        }
    }
}
