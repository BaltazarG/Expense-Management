using ExpenseManagement.Entities;

namespace ExpenseManagement.Services.Interfaces
{
    public interface IJwtGeneratorService
    {
        public string? GenerateAuthToken(User user, ICollection<string> roles);
    }
}
