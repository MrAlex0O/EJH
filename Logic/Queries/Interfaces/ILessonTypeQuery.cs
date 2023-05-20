using Logic.DTOs.LessonType;

namespace Logic.Queries.Interfaces
{
    public interface ILessonTypeQuery
    {
        public Task<IEnumerable<GetLessonTypeResponse>> GetAll();
        public Task<GetLessonTypeResponse> Get(Guid id);
    }
}
