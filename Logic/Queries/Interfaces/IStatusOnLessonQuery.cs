using Logic.DTOs.StatusOnLesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Queries.Interfaces
{
    public interface IStatusOnLessonQuery
    {
        public Task<IEnumerable<GetStatusOnLessonResponse>> GetAll();
        public Task<GetStatusOnLessonResponse> Get(Guid id);
    }
}
