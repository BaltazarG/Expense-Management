using AutoMapper;
using ExpenseManagement.Entities;
using ExpenseManagement.Models;
using ExpenseManagement.Repositories.Interfaces;
using ExpenseManagement.Services.Interfaces;

namespace ExpenseManagement.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }
        public void DeleteUser(string userId)
        {
            _userRepository.DeleteUser(userId);
        }

        public void UpdateUser(UserToUpdateDto userUpdated, string userId)
        {
            var userToUpdate = _userRepository.GetUser(userId);

            if (userToUpdate == null)
                return;

            _mapper.Map(userUpdated , userToUpdate);
            _userRepository.SaveChanges();
        }

        public UserDto? GetUser(string userId)
        {
            var user = _userRepository.GetUser(userId);

            return _mapper.Map<UserDto>(user);
            
        }

        public ICollection<UserDto>? GetUsers()
        {
            var users = _userRepository.GetUsers().ToList();
            var usersMapped = _mapper.Map<ICollection<UserDto>>(users);

            if (users == null || users.Count() == 0)
                return null;

            return usersMapped;
        }
    }
}
