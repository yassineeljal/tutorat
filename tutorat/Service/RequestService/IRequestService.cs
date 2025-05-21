using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data.Model;

namespace tutorat.Service.RequestService
{
    public interface IRequestService
    {
        Task CreateRequestAsync(Request request);
        Task DeleteRequestAsync(int id);
        Task<IEnumerable<Request>> GetAllRequestsAsync();
        Task<Request> GetRequestByIdAsync(int id);
        Task<IEnumerable<Request>> GetRequestsByStudentAsync(Student student);
    }
}
