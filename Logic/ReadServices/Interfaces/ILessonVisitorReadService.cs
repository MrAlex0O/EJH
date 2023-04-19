using Logic.DTOs.LessonVisitors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ReadServices.Interfaces
{
    public interface ILessonVisitorReadService
    {
        public Task<IEnumerable<GetLessonVisitorResponse>> GetAll();
        public Task<GetLessonVisitorResponse> GetByLessonId(Guid id);
    }
}
