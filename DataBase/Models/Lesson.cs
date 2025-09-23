namespace DataBase.Models
{
    public class Lesson : BaseModel
    {
        public Guid? DisciplineId { get; set; }
        public Discipline? Discipline { get; set; }
        public Guid? LessonTypeId { get; set; }
        public LessonType? LessonType { get; set; }
        public DateTime Date { get; set; }
        public int SequenceNumber { get; set; }
        public IEnumerable<LessonVisitor> LessonVisitors { get; set; }
    }
}
