using Microsoft.AspNetCore.Identity;

namespace ExpenseManagement.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
