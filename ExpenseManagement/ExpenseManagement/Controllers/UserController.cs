using ExpenseManagement.Models;
using ExpenseManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer", Roles = "admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {
            _userService = userService;
        }

       

        [HttpPut("{userId}")]
        public ActionResult UpdateUser(UserToUpdateDto userToUpdateDto, string userId)
        {


            if (userToUpdateDto == null)
               return BadRequest();

            var user = _userService.GetUser(userId);

            if (user == null)
                return NotFound();

            _userService.UpdateUser(userToUpdateDto, userId);


           return Ok("User updated successfully");
        }

        [HttpDelete("{userId}")]
        public ActionResult DeleteUser(string userId)
        {

            var user = _userService.GetUser(userId);

            if (user == null)
                return NotFound();


            _userService.DeleteUser(userId);


            return Ok("User deleted successfully");
        }

        [HttpGet("{userId}")]
        public ActionResult GetUser(string userId)
        {

            var user = _userService.GetUser(userId);

            if (user == null)
                return NotFound();


            return Ok(user);
        }

        [HttpGet()]
        public ActionResult GetUsers()
        {

            var users = _userService.GetUsers();

            if (users == null || users.Count() == 0)
                return NotFound();


            return Ok(users);
        }

    }
}
