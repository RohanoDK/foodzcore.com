using foodzcore.Data;
using foodzcore.Models;

namespace foodzcore.Services.AccountServices
{
    public class AccountDeleteService
    {
        private readonly foodzcoreEFDBContext _context;

        public AccountDeleteService(foodzcoreEFDBContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteAccountAsync(int accountId)
        {

            var accountToDelete = await _context.Accounts.FindAsync(accountId);

            if (accountToDelete != null)
            {
                _context.Accounts.Remove(accountToDelete);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }
    }
}
