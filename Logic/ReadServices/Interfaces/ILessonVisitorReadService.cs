using Logic.DTOs.LessonVisitor;

namespace Logic.ReadServices.Interfaces
{
    public interface ILessonVisitorReadService
    {
        public Task<IEnumerable<GetLessonVisitorResponse>> GetAll();
        public Task<GetLessonVisitorResponse> GetByLessonId(Guid id);
    }
}
