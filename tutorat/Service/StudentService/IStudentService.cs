using data.Model;

namespace tutorat.Service.StudentService
{
    public interface IStudentService
    {
        void Create(Student student);
        void Update(Student student);
        void Delete(int id);
        Student GetByDa(int Da);
        IEnumerable<Student> GetAll();
    }
}
