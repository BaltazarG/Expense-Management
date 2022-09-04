using AutoMapper;
using ExpenseManagement.Entities;
using ExpenseManagement.Models;

namespace ExpenseManagement.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
    

            CreateMap<UserDto, User>();
            CreateMap<User, UserToUpdateDto>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}
