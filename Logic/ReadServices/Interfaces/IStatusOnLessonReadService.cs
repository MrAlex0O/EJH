using Logic.DTOs.StatusOnLesson;

namespace Logic.ReadServices.Interfaces
{
    public interface IStatusOnLessonReadService
    {
        public Task<IEnumerable<GetStatusOnLessonResponse>> GetAll();
        public Task<GetStatusOnLessonResponse> Get(Guid id);
    }
}
