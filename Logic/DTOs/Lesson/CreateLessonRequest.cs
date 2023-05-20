namespace Logic.DTOs.Lesson
{
    public class CreateLessonRequest
    {
        public Guid DisciplineId { get; set; }
        public Guid LessonTypeId { get; set; }
        public DateTime Date { get; set; }
        public int SequenceNumber { get; set; }
    }
}
