using Logic.DTOs.LessonVisitor;

namespace Logic.Queries.Interfaces
{
    public interface ILessonVisitorQuery
    {
        public Task<IEnumerable<GetLessonVisitorResponse>> GetAll();
        public Task<GetLessonVisitorResponse> GetByLessonId(Guid id);
    }
}
