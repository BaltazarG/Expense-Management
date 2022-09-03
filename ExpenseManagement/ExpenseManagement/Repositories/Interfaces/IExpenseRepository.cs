using ExpenseManagement.Entities;

namespace ExpenseManagement.Repositories.Interfaces
{
    public interface IExpenseRepository : IRepository
    {
        void AddExpense(Expense newExpense);
        ICollection<Expense>? GetAllExpenses(string userId);
        Expense? GetExpense(int expenseId, string userId);
        void DeleteExpense(int expenseId);
    }
}
