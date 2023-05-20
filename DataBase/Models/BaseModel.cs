namespace DataBase.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime DateCreate { get; set; }
        public DateTime DateUpdate { get; set; }
    }
}
