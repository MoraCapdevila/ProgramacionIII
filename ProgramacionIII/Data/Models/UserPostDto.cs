using System.ComponentModel.DataAnnotations;

namespace ProgramacionIII.Data.Models
{
    public class UserPostDto
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        public string? Password { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string UserType { get; set; }
    }
}
