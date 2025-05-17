
using data.Model;

namespace tutorat.Service.TeacherService
{
    public interface ITeacherService
    {
        void Create(Teacher teacher);
        void Update(Teacher teacher);
        void Delete(int id);
    }
}
