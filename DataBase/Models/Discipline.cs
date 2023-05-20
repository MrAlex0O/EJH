namespace DataBase.Models
{
    public class Discipline : BaseModel
    {
        public string Name { get; set; }
        public Guid? LectorId { get; set; }
        public Teacher? Lector { get; set; }
        public Guid? GroupId { get; set; }
        public Group? Group { get; set; }
        public int Semester { get; set; }
        public IEnumerable<Lesson> Lessons { get; set; }
    }
}
