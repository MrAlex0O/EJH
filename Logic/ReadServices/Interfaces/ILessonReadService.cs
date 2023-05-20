using Logic.DTOs.Lesson;

namespace Logic.ReadServices.Interfaces
{
    public interface ILessonReadService
    {
        public Task<IEnumerable<GetLessonResponse>> GetAll();
        public Task<GetLessonResponse> Get(Guid id);
    }
}
