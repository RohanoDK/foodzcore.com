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
