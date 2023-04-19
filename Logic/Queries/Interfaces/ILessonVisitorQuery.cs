using Logic.DTOs.LessonVisitor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Queries.Interfaces
{
    public interface ILessonVisitorQuery
    {
        public Task<IEnumerable<GetLessonVisitorResponse>> GetAll();
        public Task<GetLessonVisitorResponse> GetByLessonId(Guid id);
    }
}
