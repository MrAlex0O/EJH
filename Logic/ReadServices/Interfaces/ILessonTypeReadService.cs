using Logic.DTOs.LessonType;

namespace Logic.ReadServices.Interfaces
{
    public interface ILessonTypeReadService
    {
        public Task<IEnumerable<GetLessonTypeResponse>> GetAll();
        public Task<GetLessonTypeResponse> Get(Guid id);
    }
}
