using ExpenseManagement.Contexts;
using ExpenseManagement.Repositories.Interfaces;

namespace ExpenseManagement.Repositories.Implementations
{
    public class Repository : IRepository
    {
        internal readonly ApplicationExpenseContext _context;

        public Repository(ApplicationExpenseContext context)
        {
            _context = context;
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
