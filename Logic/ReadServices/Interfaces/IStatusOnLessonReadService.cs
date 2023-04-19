using Logic.DTOs.StatusOnLesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ReadServices.Interfaces
{
    public interface IStatusOnLessonReadService
    {
        public Task<IEnumerable<GetStatusOnLessonResponse>> GetAll();
        public Task<GetStatusOnLessonResponse> Get(Guid id);
    }
}
