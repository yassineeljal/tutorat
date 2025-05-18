
using data.Model;

namespace tutorat.Service.TeacherService
{
    public interface ITeacherService
    {
        Teacher GetByLastName(string lastName);
        void Create(Teacher teacher);
        void Update(Teacher teacher);
        void Delete(int id);
    }
}
