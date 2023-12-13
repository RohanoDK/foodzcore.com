using foodzcore.Data;
using Microsoft.EntityFrameworkCore;

namespace foodzcore.Services.LoginServices
{
    public class foodzcoreAuthenticationService
    {
        private readonly foodzcoreEFDBContext _context;

        public foodzcoreAuthenticationService(foodzcoreEFDBContext context)
        {
            _context = context;
        }

        public bool AuthenticateUser(string username, string password)
        {
            // Logging to check the values being passed
            Console.WriteLine($"Authenticating user: {username} with password: {password}");

            // Checks database for a Username first using LINQ
            var user = _context.Accounts.FirstOrDefault(u => u.Username == username);


            // If User is not null (matching username) then we test the password matches the username - If true then Authentification is succesful - If not it will return false.
            if (user != null && password == user.Password)
            {
                // Test logging to check spell out the result
                Console.WriteLine("Authentication successful");

                // If a user is found and the password matches, authentication is successful
                return true;
            }

            // Test logging to check spell out the result
            Console.WriteLine("Authentication failed");

            return false;

        }
    }
}
    