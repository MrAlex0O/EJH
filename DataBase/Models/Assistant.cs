namespace DataBase.Models
{
    public class Assistant : BaseModel
    {
        public Guid? DisciplineId { get; set; }
        public Discipline Discipline { get; set; }
        public Guid? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
