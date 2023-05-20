namespace Logic.DTOs.LessonVisitor
{
    public class UpdateLessonVisitorRequest
    {
        public Guid LessonId { get; set; }
        public Guid StudentId { get; set; }
        public Guid StatusId { get; set; }
    }
}
