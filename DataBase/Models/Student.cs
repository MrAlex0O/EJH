namespace DataBase.Models
{
    public class Student : BaseModel
    {
        public Guid? PersonId { get; set; }
        public virtual Person? Person { get; set; }
        public Guid? GroupId { get; set; }
        public virtual Group? Group { get; set; }

    }
}
