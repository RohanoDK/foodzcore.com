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
                    await _context.SaveChangesAsync();
                    return true;
                }
                catch (DbUpdateConcurrencyException)
                {
                    return false;
                }
            }

            return false;
        }
    }
}
