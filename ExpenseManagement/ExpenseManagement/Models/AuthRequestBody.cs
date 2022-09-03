using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.Models
{
    public class AuthRequestBody
    {
        [Required]
        [MaxLength(100)]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = string.Empty;
    }
}
