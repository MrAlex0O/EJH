namespace Logic.DTOs.Lesson
{
    public class UpdateLessonRequest
    {
        public Guid DisciplineId { get; set; }
        public Guid LessonTypeId { get; set; }
        public DateTime Date { get; set; }
        public int SequenceNumber { get; set; }
    }
}
