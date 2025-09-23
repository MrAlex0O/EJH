using System.Text.Json.Serialization;

namespace DataBase.Models
{
    public class User : BaseModel
    {
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public string Username { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }
    }
}
