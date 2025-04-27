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
        void CreateRequest(Request request);
        void DeleteRequest(int id);
        IEnumerable<Request> GetAllRequests();
        Request GetRequestById(int id);
        IEnumerable<Request> GetRequestsByStudent(Student student);
    }
}
