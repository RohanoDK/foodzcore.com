using foodzcore.Data;
using foodzcore.Models;

namespace foodzcore.Services.AccountServices
{
    public class AccountCreateService
    {
        private readonly foodzcoreEFDBContext _context;

        public AccountCreateService(foodzcoreEFDBContext context)
        {
            _context = context;
        }

        public async Task<Account> CreateAccountAsync(string username, string password, string email, bool isAdmin)
        {
            // Determine the role based on isAdmin
            string role = isAdmin ? "admin" : "user";

            var newAccount = new Account
            {
                Username = username,
                Password = password,
                Email = email,
                Role = role,
            };

            _context.Accounts.Add(newAccount);
            await _context.SaveChangesAsync();

            return newAccount;
        }
    }
}
