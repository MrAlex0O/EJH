using Logic.DTOs.Discipline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Queries.Interfaces
{
    public interface IDisciplineQuery
    {
        public Task<IEnumerable<GetDisciplineResponse>> GetAll();
        public Task<GetDisciplineResponse> Get(Guid id);
        public Task<IEnumerable<GetDisciplineResponse>> GetByTeacherId(Guid teacherId);
    }
}
