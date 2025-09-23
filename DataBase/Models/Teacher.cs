namespace DataBase.Models
{
    public class Teacher : BaseModel
    {
        public Guid? PersonId { get; set; }
        public virtual Person? Person { get; set; }
    }
}
