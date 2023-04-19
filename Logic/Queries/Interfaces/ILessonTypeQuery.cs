using Logic.DTOs.LessonType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Queries.Interfaces
{
    public interface ILessonTypeQuery
    {
        public Task<IEnumerable<GetLessonTypeResponse>> GetAll();
        public Task<GetLessonTypeResponse> Get(Guid id);
    }
}
