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

            var accountToDelete = await _context.Recipes.FindAsync(accountId);

            if (accountToDelete != null)
            {
                _context.Recipes.Remove(accountToDelete);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }
    }
}
