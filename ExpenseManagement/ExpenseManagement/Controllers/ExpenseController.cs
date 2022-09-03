using ExpenseManagement.Entities;
using ExpenseManagement.Models;
using ExpenseManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExpenseManagement.Controllers
{
    [Route("api/expenses/{userId}")]
    [ApiController]
    [Authorize]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;


        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ExpenseDto>>> GetExpenses(string userId)
        {

            

            var expenses = _expenseService.GetAllExpenses(userId);
            

            if (expenses == null)
                return NotFound("You dont have expenses");
 

            return Ok(expenses);
        }

        [HttpGet("{expenseId}")]
        public async Task<ActionResult<ExpenseDto>> GetExpense(string userId, int expenseId)
        {


            var expense = _expenseService.GetExpense(expenseId, userId);



            if (expense is null)
                return NotFound("Expense not found");


            return Ok(expense);
        }

        [HttpPost]
        public async Task<ActionResult<ICollection<ExpenseDto>>> AddExpense(ExpenseToCreationDto expenseToCreation)
        {

            if (expenseToCreation == null)
                return BadRequest();

            _expenseService.AddExpense(expenseToCreation);


            return Ok("Expense created successfully");
        }


        [HttpPut("{expenseId}")]
        public async Task<ActionResult<ICollection<ExpenseDto>>> UpdateExpense(ExpenseToUpdateDto expenseToUpdate, int expenseId, string userId)
        {


            if (expenseToUpdate == null)
                return BadRequest();

            _expenseService.UpdateExpense(expenseToUpdate, expenseId, userId);


            return Ok("Expense updated successfully");
        }

        [HttpDelete("{expenseId}")]
        public async Task<ActionResult<ICollection<ExpenseDto>>> DeleteExpense(int expenseId, string userId)
        {



            _expenseService.DeleteExpense(expenseId);


            return Ok("Expense updated successfully");
        }
    }
}
