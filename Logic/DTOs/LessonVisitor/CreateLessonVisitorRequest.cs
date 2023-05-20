namespace Logic.DTOs.LessonVisitor
{
    public class CreateLessonVisitorRequest
    {
        public Guid LessonId { get; set; }
        public Guid StudentId { get; set; }
        public Guid StatusOnLessonId { get; set; }
    }
}
