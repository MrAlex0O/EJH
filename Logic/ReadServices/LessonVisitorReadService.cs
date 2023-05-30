using Logic.DTOs.LessonVisitor;
using Logic.Queries.Interfaces;
using Logic.ReadServices.Interfaces;

namespace Logic.ReadServices
{
    public class LessonVisitorReadService : ILessonVisitorReadService
    {
        ILessonVisitorQuery _groupQuery;
        public LessonVisitorReadService(ILessonVisitorQuery query)
        {
            _groupQuery = query;
        }

        public async Task<IEnumerable<GetLessonVisitorResponse>> GetAll()
        {
            return await _groupQuery.GetAll();
        }

        public async Task<GetLessonVisitorResponse> GetByLessonId(Guid id)
        {
            return await _groupQuery.GetByLessonId(id);
        }
    }
}
