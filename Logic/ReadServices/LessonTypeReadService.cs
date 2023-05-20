using Logic.DTOs.LessonType;
using Logic.Queries.Interfaces;
using Logic.ReadServices.Interfaces;

namespace Logic.ReadServices
{
    public class LessonTypeReadService : ILessonTypeReadService
    {
        ILessonTypeQuery _lessonTypeQuery;
        public LessonTypeReadService(ILessonTypeQuery query)
        {
            _lessonTypeQuery = query;
        }
        public async Task<IEnumerable<GetLessonTypeResponse>> GetAll()
        {
            return await _lessonTypeQuery.GetAll();
        }
        public async Task<GetLessonTypeResponse> Get(Guid id)
        {
            return await _lessonTypeQuery.Get(id);
        }
    }
}
