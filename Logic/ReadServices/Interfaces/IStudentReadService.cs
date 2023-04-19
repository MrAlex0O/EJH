using Logic.DTOs.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ReadServices.Interfaces
{
    public interface IStudentReadService
    {
        public Task<IEnumerable<GetStudentResponse>> GetAll();
        public Task<GetStudentResponse> Get(Guid id);
        public Task<IEnumerable<GetStudentResponse>> GetByGroupId(Guid groupIdd);
    }
}
