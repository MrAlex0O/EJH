using Logic.DTOs.StatusOnLesson;

namespace Logic.Queries.Interfaces
{
    public interface IStatusOnLessonQuery
    {
        public Task<IEnumerable<GetStatusOnLessonResponse>> GetAll();
        public Task<GetStatusOnLessonResponse> Get(Guid id);
    }
}
