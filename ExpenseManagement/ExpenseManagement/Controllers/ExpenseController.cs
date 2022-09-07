

using ExpenseManagement.Models;
using ExpenseManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ExpenseManagement.Controllers
{
    [Route("api/expenses/{userId}")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "User")]

    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;


        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet]
        public ActionResult<ICollection<ExpenseDto>> GetExpenses(string userId)
        {
           

            var expenses = _expenseService.GetAllExpenses(userId);
            

            if (expenses == null || expenses.Count() == 0)
                return NotFound("You dont have expenses");
 

            return Ok(expenses);
        }

        [HttpGet("{expenseId}")]
        public ActionResult<ExpenseDto> GetExpense(string userId, int expenseId)
        {


            var expense = _expenseService.GetExpense(expenseId, userId);



            if (expense is null)
                return NotFound("Expense not found");


            return Ok(expense);
        }

        [HttpPost]
        public ActionResult<ICollection<ExpenseDto>> AddExpense(ExpenseToCreationDto expenseToCreation, string userId)
        {

            if (expenseToCreation == null)
                return BadRequest();

            _expenseService.AddExpense(expenseToCreation, userId);


            return Ok("Expense created successfully");
        }


        [HttpPut("{expenseId}")]
        public ActionResult<ICollection<ExpenseDto>> UpdateExpense(ExpenseToUpdateDto expenseToUpdate, int expenseId, string userId)
        {


            if (expenseToUpdate == null)
                return BadRequest();

            var expense = _expenseService.GetExpense(expenseId, userId);


            if (expense is null)
                return NotFound("Expense not found");


            _expenseService.UpdateExpense(expenseToUpdate, expenseId, userId);


            return Ok("Expense updated successfully");
        }

        [HttpDelete("{expenseId}")]
        public ActionResult<ICollection<ExpenseDto>> DeleteExpense(int expenseId, string userId)
        {

            var expense = _expenseService.GetExpense(expenseId, userId);


            if (expense is null)
                return NotFound("Expense not found");


            _expenseService.DeleteExpense(expenseId);


            return Ok("Expense deleted successfully");
        }
    }
}
