using ExpenseManagement.Enums;
using System.ComponentModel.DataAnnotations;

namespace ExpenseManagement.Models
{
    public class ExpenseToCreationDto
    {
        public string Description { get; set; } = string.Empty;
        [Required]
        public double Amount { get; set; }
        [Required]
        public Category Category { get; set; }

        [Required]
        public string UserId { get; set; }

    }
}
