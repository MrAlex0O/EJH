using Logic.DTOs.Discipline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ReadServices.Interfaces
{
    public interface IDisciplineReadService
    {
        public Task<IEnumerable<GetDisciplineResponse>> GetAll();
        public Task<GetDisciplineResponse> Get(Guid id);
        public Task<IEnumerable<GetDisciplineResponse>> GetByTeacherId(Guid TeacherId);
    }
}
