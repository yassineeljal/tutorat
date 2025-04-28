using data;
using data.Model;

namespace tutorat.Service.RequestService
{
    public class RequestService : IRequestService
    {
        private ModelDbContext _db = new ModelDbContext();

        public void CreateRequest(Request request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            _db.Requests.Add(request);
            _db.SaveChanges();

        }

        public void DeleteRequest(int id)
        {
            var request = _db.Requests.Find(id);
            if (request != null)
            {
                _db.Requests.Remove(request);
                _db.SaveChanges();
            }
            else
            {
                throw new ArgumentException($"Request with id {id} not found.");
            }
        }

        public IEnumerable<Request> GetAllRequests()
        {
            return _db.Requests.ToList();
        }

        public Request GetRequestById(int id)
        {
            var request = _db.Requests.Find(id);
            if (request == null)
            {
                throw new ArgumentException($"Request with id {id} not found.");
            }
            return request;
        }

        public IEnumerable<Request> GetRequestsByStudent(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            return _db.Requests.Where(r => r.StudentId == student.Id).ToList();
        }


    }
}
