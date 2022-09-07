using ExpenseManagement.Entities;

namespace ExpenseManagement.Repositories.Interfaces
{
    public interface IUserRepository : IRepository
    {
        void DeleteUser(string userId);
        User? GetUser(string userId);
        ICollection<User> GetUsers();

    }


}
