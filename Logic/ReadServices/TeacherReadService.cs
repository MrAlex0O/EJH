using Logic.DTOs.Teacher;
using Logic.Queries.Interfaces;
using Logic.ReadServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ReadServices
{
    public class TeacherReadService : ITeacherReadService
    {
        ITeacherQuery _teacherQuery;
        public TeacherReadService(ITeacherQuery teacherQuery)
        {
            _teacherQuery = teacherQuery;
        }

        public async Task<IEnumerable<GetTeacherResponse>> GetAll()
        {
            return await _teacherQuery.GetAll();
        }
        public async Task<GetTeacherResponse> Get(Guid id)
        {
            return await _teacherQuery.Get(id);
        }
    }
}
