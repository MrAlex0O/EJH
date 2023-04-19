using Logic.DTOs.Student;
using Logic.Queries.Interfaces;
using Logic.ReadServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ReadServices
{
    public class StudentReadService : IStudentReadService
    {
        IStudentQuery _studentQuery;
        public StudentReadService(IStudentQuery studentQuery)
        {
            _studentQuery = studentQuery;
        }

        public async Task<IEnumerable<GetStudentResponse>> GetAll()
        {
            return await _studentQuery.GetAll();
        }

        public async Task<GetStudentResponse> Get(Guid id)
        {
            return await _studentQuery.Get(id);
        }
        public async Task<IEnumerable<GetStudentResponse>> GetByGroupId(Guid groupId)
        {
            return await _studentQuery.GetByGroupId(groupId);
        }
    }
}
