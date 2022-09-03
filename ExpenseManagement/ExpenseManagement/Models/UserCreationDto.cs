using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.Models
{
    public class UserCreationDto
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;
        
    }
}
