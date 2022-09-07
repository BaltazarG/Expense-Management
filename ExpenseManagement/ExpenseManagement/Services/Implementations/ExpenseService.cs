using AutoMapper;
using ExpenseManagement.Entities;
using ExpenseManagement.Models;
using ExpenseManagement.Repositories.Interfaces;
using ExpenseManagement.Services.Interfaces;

namespace ExpenseManagement.Services.Implementations
{
    public class ExpenseService : IExpenseService
    {
        private readonly IMapper _mapper;
        private readonly IExpenseRepository _expenseRepository;

        public ExpenseService(IMapper mapper, IExpenseRepository expenseRepository)
        {
            _mapper = mapper;
            _expenseRepository = expenseRepository;
        }

        public void AddExpense(ExpenseToCreationDto newExpense, string userId)
        {
            if (newExpense is null)
                return;

            Expense expenseMapped = _mapper.Map<Expense>(newExpense);

            expenseMapped.UserId = userId;
            _expenseRepository.AddExpense(expenseMapped);
        }

        public void DeleteExpense(int expenseId)
        {
            _expenseRepository.DeleteExpense(expenseId);
        }

        public ICollection<ExpenseDto>? GetAllExpenses(string userId)
        {
            var expenses = _expenseRepository.GetAllExpenses(userId);
            

            return _mapper.Map<ICollection<ExpenseDto>>(expenses);



        }

        public ExpenseDto? GetExpense(int expenseId, string userId)
        {
            var expense = _expenseRepository.GetExpense(expenseId, userId);
            
            return _mapper.Map<ExpenseDto>(expense);
        }

        public void UpdateExpense(ExpenseToUpdateDto updatedExpense, int expenseToUpdateId, string userId)
        {
            var expenseToUpdate = _expenseRepository.GetExpense(expenseToUpdateId, userId);

            if (expenseToUpdate == null)
                return;

            _mapper.Map(updatedExpense, expenseToUpdate);
            _expenseRepository.SaveChanges();
            
        }
    }
}
