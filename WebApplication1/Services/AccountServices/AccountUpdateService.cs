using foodzcore.Data;
using foodzcore.Models;
using Microsoft.EntityFrameworkCore;

namespace foodzcore.Services.AccountServices
{
    public class AccountUpdateService
    {
        private readonly foodzcoreEFDBContext _context;

        public AccountUpdateService(foodzcoreEFDBContext context)
        {
            _context = context;
        }

        public async Task<bool> UpdateAccountAsync(Account updatedaccount)
        {
            if (updatedaccount != null)
            {

                _context.Attach(updatedaccount).State = EntityState.Modified;

                try
                {
                    // Save changes to the database
                    await _context.SaveChangesAsync();
                    return true; // Update successful
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Handle concurrency exception, if needed
                    // This occurs when another user has modified the same recipe concurrently
                    return false;
                }
            }

            return false; // Account not found or other issues
        }
    }
}
