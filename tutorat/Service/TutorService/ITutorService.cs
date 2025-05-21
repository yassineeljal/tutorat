using data.Model;

namespace tutorat.Service.TutorService
{
    public interface ITutorService
    {
        Task<Tutor> GetByDaAsync(int da);
        Task<IEnumerable<Tutor>> GetAllAsync();
        Task CreateAsync(Tutor tutor);
        Task UpdateAsync(Tutor tutor);
        Task DeleteAsync(int da);



    }
}
