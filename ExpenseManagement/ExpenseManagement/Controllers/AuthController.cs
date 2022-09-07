using AutoMapper;
using ExpenseManagement.Entities;
using ExpenseManagement.Models;
using ExpenseManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseManagement.Controllers
{
	[Route("api/auth")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly UserManager<User> _userManager;
		private readonly IJwtGeneratorService _jwtGeneratorService;
        private readonly IMapper _mapper;

        public AuthController(UserManager<User> userManager, IJwtGeneratorService jwtGeneratorService, IMapper mapper)
		{
			_userManager = userManager;
			_jwtGeneratorService = jwtGeneratorService;
			_mapper = mapper;
		}

		[HttpPost]
		public async Task<ActionResult<string>> AuthUser(AuthRequestBody request)
		{
			var user = await _userManager.FindByNameAsync(request.UserName);

			if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
			{
				return Forbid();
			}

			var roles = await _userManager.GetRolesAsync(user);

			var jwt = _jwtGeneratorService.GenerateAuthToken(user, roles);


			return Ok(jwt);
		}

		[HttpPost("/signup")]
		public async Task<ActionResult<string>> RegisterUser(UserCreationDto user)
		{
			var newUser = _mapper.Map<User>(user);

			var result = await _userManager.CreateAsync(newUser, user.Password);
			if (result.Succeeded)
			{
				var userToToken = await _userManager.FindByNameAsync(user.UserName);

				if (userToToken == null)
					return BadRequest();

				await _userManager.AddToRoleAsync(userToToken, "User");


				var roles = await _userManager.GetRolesAsync(userToToken);

				var jwt_signup = _jwtGeneratorService.GenerateAuthToken(userToToken, roles);



				if (jwt_signup != null)
                {
					return jwt_signup;
                }
				
			}
			return BadRequest(result); 
		}
	}
}
