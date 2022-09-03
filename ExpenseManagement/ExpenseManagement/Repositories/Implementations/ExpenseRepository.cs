using ExpenseManagement.Contexts;
using ExpenseManagement.Entities;
using ExpenseManagement.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManagement.Repositories.Implementations
{
    public class ExpenseRepository : Repository, IExpenseRepository
    {
        public ExpenseRepository(ApplicationExpenseContext context) : base(context)
        {

        }


        public void AddExpense(Expense newExpense)
        {
            if (newExpense is null)
                return;

            _context.Expenses?.Add(newExpense);
            _context.SaveChanges();
        }

        public void DeleteExpense(int expenseId)
        {
            Expense expense = new() { Id = expenseId };
            _context.Remove(expense);
            _context.SaveChanges();
        }

        public ICollection<Expense>? GetAllExpenses(string userId)
        {
            return _context.Expenses?.Where(e => e.UserId == userId).ToList();
        }

        public Expense? GetExpense(int expenseId, string userId)
        {
            return _context.Expenses?.Where(e => e.Id == expenseId && e.UserId == userId).FirstOrDefault();
        }

        
    }
}
