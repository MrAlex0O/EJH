using Logic.DTOs.Lesson;

namespace Logic.WriteServices.Interfaces
{
    public interface ILessonWriteService
    {
        public Guid Add(CreateLessonRequest createLessonRequest);
        public void Update(Guid id, UpdateLessonRequest updateLessonRequest);
        public void Delete(Guid id);
    }
}
