namespace API.Authorization.Models
{
    public class AuthResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
