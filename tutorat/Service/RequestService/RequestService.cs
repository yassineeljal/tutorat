using data;
using data.Model;
using Microsoft.EntityFrameworkCore;

namespace tutorat.Service.RequestService
{
    public class RequestService : IRequestService
    {
        private readonly ModelDbContext _db = new ModelDbContext();

        public async Task CreateRequestAsync(Request request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            await _db.Requests.AddAsync(request);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteRequestAsync(int id)
        {
            var request = await _db.Requests.FindAsync(id);
            if (request != null)
            {
                _db.Requests.Remove(request);
                await _db.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentException($"Request with id {id} not found.");
            }
        }

        public async Task<IEnumerable<Request>> GetAllRequestsAsync()
        {
            return await _db.Requests.ToListAsync();
        }

        public async Task<Request> GetRequestByIdAsync(int id)
        {
            var request = await _db.Requests.FindAsync(id);
            if (request == null)
            {
                throw new ArgumentException($"Request with id {id} not found.");
            }
            return request;
        }

        public async Task<IEnumerable<Request>> GetRequestsByStudentAsync(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }
            return await _db.Requests
                            .Where(r => r.StudentId == student.Id)
                            .ToListAsync();
        }


    }
}
