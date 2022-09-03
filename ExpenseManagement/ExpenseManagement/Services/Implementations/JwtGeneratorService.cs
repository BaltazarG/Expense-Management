using ExpenseManagement.Entities;
using ExpenseManagement.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ExpenseManagement.Services.Implementations
{
    public class JwtGeneratorService : IJwtGeneratorService
    {
		private readonly IConfiguration _config;

		public JwtGeneratorService(IConfiguration config)
		{
			_config = config;
		}

		public string? GenerateAuthToken(User user, ICollection<string> roles)
		{
			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Sid, user.Id),
				new Claim(ClaimTypes.Name, user.UserName),
				new Claim(ClaimTypes.GivenName, $"{user.FirstName} {user.LastName}")
			};

			foreach (var role in roles)
			{
				claims.Add(new Claim(ClaimTypes.Role, role));
			}

			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Authentication:SecretForKey"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
			var tokenDescriptor = new JwtSecurityToken(
				issuer: _config["Jwt:Issuer"],
				audience: _config["Jwt:Audience"],
				claims: claims,
				expires: DateTime.Now.AddMinutes(720),
				signingCredentials: credentials);

			var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

			return jwt;

		}
	}
}
