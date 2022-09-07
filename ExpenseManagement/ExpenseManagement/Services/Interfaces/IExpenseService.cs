using ExpenseManagement.Entities;
using ExpenseManagement.Models;

namespace ExpenseManagement.Services.Interfaces
{
    public interface IExpenseService
    {
        void AddExpense(ExpenseToCreationDto newExpense, string userId);
        ICollection<ExpenseDto>? GetAllExpenses(string userId);
        ExpenseDto? GetExpense(int expenseId, string userId);
        void DeleteExpense(int expenseId);
        void UpdateExpense(ExpenseToUpdateDto updatedExpense, int expenseToUpdateId, string userId);
    }
}
