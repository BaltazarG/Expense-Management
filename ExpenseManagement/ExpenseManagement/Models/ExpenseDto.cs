using ExpenseManagement.Enums;

namespace ExpenseManagement.Models
{
    public class ExpenseDto
    {   
        public int Id { get; set; }   
        public string Description { get; set; } = string.Empty;
        public double Amount { get; set; }
        public Category Category { get; set; }

    }
}
