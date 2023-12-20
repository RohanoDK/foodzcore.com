using foodzcore.Data;
using foodzcore.Models;

namespace foodzcore.Services.AccountServices
{
    public class AccountReadService
    {
        private readonly foodzcoreEFDBContext _context;

        public AccountReadService(foodzcoreEFDBContext context)
        {
            _context = context;
        }

        public Account GetUserByUsernameAndPassword(string username, string password)
        {
            // Logging to check the values being passed
            Console.WriteLine($"Authenticating user: {username} with password: {password}");

            // Checks database for a Username first using LINQ
            var user = _context.Accounts.FirstOrDefault(u => u.Username == username && u.Password == password);

            return user;
        }

        public Account GetUserByID(int id)
        {
            var user = _context.Accounts.FirstOrDefault(u => u.UserID == id);
            return user;
        }
    }
}
