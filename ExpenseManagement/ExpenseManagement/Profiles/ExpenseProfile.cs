using AutoMapper;
using ExpenseManagement.Entities;
using ExpenseManagement.Models;

namespace ExpenseManagement.Profiles
{
    public class ExpenseProfile : Profile
    {
        public ExpenseProfile()
        {
            CreateMap<ExpenseToCreationDto, Expense>();       
            CreateMap<Expense, ExpenseToCreationDto>();


            CreateMap<ExpenseToUpdateDto, Expense>();
            CreateMap<Expense, ExpenseToUpdateDto>();

            CreateMap<Expense, ExpenseDto>();
            CreateMap<ExpenseDto, Expense>();
        }
    }
}
