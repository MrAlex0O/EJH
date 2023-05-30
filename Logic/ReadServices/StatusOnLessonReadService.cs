using Logic.DTOs.StatusOnLesson;
using Logic.Queries.Interfaces;
using Logic.ReadServices.Interfaces;

namespace Logic.ReadServices
{
    public class StatusOnLessonReadService : IStatusOnLessonReadService
    {
        IStatusOnLessonQuery _statusOnLessonQuery;
        public StatusOnLessonReadService(IStatusOnLessonQuery query)
        {
            _statusOnLessonQuery = query;
        }
        public async Task<IEnumerable<GetStatusOnLessonResponse>> GetAll()
        {
            return await _statusOnLessonQuery.GetAll();
        }
        public async Task<GetStatusOnLessonResponse> Get(Guid id)
        {
            return await _statusOnLessonQuery.Get(id);
        }
    }
}
