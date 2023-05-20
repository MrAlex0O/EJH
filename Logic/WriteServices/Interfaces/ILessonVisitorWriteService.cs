using Logic.DTOs.LessonVisitor;

namespace Logic.WriteServices.Interfaces
{
    public interface ILessonVisitorWriteService
    {
        public void Add(CreateLessonVisitorRequest createlessonsVisitors);
        public void Update(Guid id, UpdateLessonVisitorRequest updatelessonsVisitors);
        public void Delete(Guid id);
    }
}
