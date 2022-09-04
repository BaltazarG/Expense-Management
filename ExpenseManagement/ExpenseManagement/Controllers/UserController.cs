using ExpenseManagement.Models;
using ExpenseManagement.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
        }

       

        [HttpPut("{userId}")]
        public ActionResult UpdateExpense(UserToUpdateDto userToUpdateDto, string userId)
        {


            if (userToUpdateDto == null)
               return BadRequest();

            _userService.UpdateUser(userToUpdateDto, userId);


           return Ok("User updated successfully");
        }

        [HttpDelete("{userId}")]
        public ActionResult DeleteExpense(string userId)
        {

            

            _userService.DeleteUser(userId);


            return Ok("User deleted successfully");
        }
    }
}
