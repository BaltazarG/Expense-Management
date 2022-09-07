
using ExpenseManagement.Models;

namespace ExpenseManagement.Services.Interfaces
{
    public interface IUserService
    {

        
        void DeleteUser(string userId);
        void UpdateUser(UserToUpdateDto userUpdated, string userId);
        UserDto? GetUser(string userId);
        ICollection<UserDto>? GetUsers();

    }
}
