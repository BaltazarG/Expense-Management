using ExpenseManagement.Contexts;
using ExpenseManagement.Entities;
using ExpenseManagement.Repositories.Interfaces;

namespace ExpenseManagement.Repositories.Implementations
{
    public class UserRepository : Repository, IUserRepository
    {
        public UserRepository(ApplicationExpenseContext context) : base(context)
        {
        }

        public void DeleteUser(string userId)
        {
            var userToDelete = _context.Users.Find(userId);
            if (userToDelete != null)
                _context.Users.Remove(userToDelete);

            _context.SaveChanges();
        }

        public User? GetUser(string userId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == userId);
        }
    }
}
