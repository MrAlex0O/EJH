using Logic.DTOs.Teacher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ReadServices.Interfaces
{
    public interface ITeacherReadService
    {
        public Task<IEnumerable<GetTeacherResponse>> GetAll();
        public Task<GetTeacherResponse> Get(Guid id);
    }
}
