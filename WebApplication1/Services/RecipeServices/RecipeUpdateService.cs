using foodzcore.Data;
using foodzcore.Models;
using Microsoft.EntityFrameworkCore;

namespace foodzcore.Services.RecipeServices
{
    public class RecipeUpdateService
    {
        private readonly foodzcoreEFDBContext _context;

        public RecipeUpdateService(foodzcoreEFDBContext context)
        {
            _context = context;
        }

        public async Task<bool> UpdateRecipeAsync(Recipe updatedrecipe)
        {
            if (updatedrecipe != null)
            {

                _context.Attach(updatedrecipe).State = EntityState.Modified;

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

            return false; // Recipe not found or other issues
        }
    }
}
