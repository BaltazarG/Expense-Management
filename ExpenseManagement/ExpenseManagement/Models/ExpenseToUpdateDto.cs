using ExpenseManagement.Enums;

namespace ExpenseManagement.Models
{
    public class ExpenseToUpdateDto
    {
        public string Description { get; set; } = string.Empty;
    
        public double Amount { get; set; }
   
        public Category Category { get; set; }

    }
}
