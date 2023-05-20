using Logic.DTOs.Lesson;
using Logic.Queries.Interfaces;
using Logic.ReadServices.Interfaces;

namespace Logic.ReadServices
{
    public class LessonReadService : ILessonReadService
    {
        ILessonQuery _lessonQuery;
        public LessonReadService(ILessonQuery lessonQuery)
        {
            _lessonQuery = lessonQuery;
        }
        public async Task<IEnumerable<GetLessonResponse>> GetAll()
        {
            return await _lessonQuery.GetAll();
        }
        public async Task<GetLessonResponse> Get(Guid id)
        {
            return await _lessonQuery.Get(id);
        }
    }
}
