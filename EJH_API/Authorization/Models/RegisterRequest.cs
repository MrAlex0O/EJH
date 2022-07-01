using System.ComponentModel.DataAnnotations;

namespace API.Authorization.Models
{
    public class RegisterRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
