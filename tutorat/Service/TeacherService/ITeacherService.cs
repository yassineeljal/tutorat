
using data.Model;

namespace tutorat.Service.TeacherService
{
    public interface ITeacherService
    {
        Task<Teacher> GetByLastNameAsync(string lastName);
        Task CreateAsync(Teacher teacher);
        Task UpdateAsync(Teacher teacher);
        Task DeleteAsync(int id);
        Task<IEnumerable<Teacher>> GetAllAsync();
    }
}
