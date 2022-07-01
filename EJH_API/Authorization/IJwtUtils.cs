using DataBase.Models;

namespace API.Authorization
{
    public interface IJwtUtils
    {
        public string GenerateToken(User user);
        public Guid? ValidateToken(string token);
    }
}
