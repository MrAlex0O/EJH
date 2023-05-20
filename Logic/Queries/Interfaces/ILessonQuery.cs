using Logic.DTOs.Lesson;

namespace Logic.Queries.Interfaces
{
    public interface ILessonQuery
    {
        public Task<IEnumerable<GetLessonResponse>> GetAll();
        public Task<GetLessonResponse> Get(Guid id);
    }
}
