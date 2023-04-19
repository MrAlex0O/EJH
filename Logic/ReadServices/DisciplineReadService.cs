using Logic.DTOs.Discipline;
using Logic.Queries.Interfaces;
using Logic.ReadServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ReadServices
{
    public class DisciplineReadService : IDisciplineReadService
    {
        IDisciplineQuery _disciplineQuery;
        public DisciplineReadService(IDisciplineQuery disciplineQuery)
        {
            _disciplineQuery = disciplineQuery;
        }
        public async Task<IEnumerable<GetDisciplineResponse>> GetAll()
        {
            return await _disciplineQuery.GetAll();
        }
        public async Task<GetDisciplineResponse> Get(Guid id)
        {
            return await _disciplineQuery.Get(id);
        }
        public async Task<IEnumerable<GetDisciplineResponse>> GetByTeacherId(Guid teacherId)
        {
            return await _disciplineQuery.GetByTeacherId(teacherId);
        }
    }
}
