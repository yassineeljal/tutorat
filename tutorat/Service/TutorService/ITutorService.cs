using data.Model;

namespace tutorat.Service.TutorService
{
    public interface ITutorService
    {
        Tutor GetByDa(int da);
        IEnumerable<Tutor> GetAll();
        void Create(Tutor tutor);
        void Update(Tutor tutor);
        void Delete(int da);



    }
}
