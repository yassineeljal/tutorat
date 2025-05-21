using data.Model;

namespace tutorat.Service.StudentService
{
    public interface IStudentService
    {
        Task<Student> GetByIdAsync(int id);
        Task CreateAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(int id);
        Task<Student> GetByDaAsync(int Da);
        Task<IEnumerable<Student>> GetAllAsync();
    }
}
