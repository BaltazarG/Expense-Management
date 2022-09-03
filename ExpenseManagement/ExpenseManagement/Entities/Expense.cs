using ExpenseManagement.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseManagement.Entities
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public double Amount { get; set; }
        [Required]
        public Category Category { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public string UserId { get; set; } = string.Empty;

    }
}
