using foodzcore.Data;
using foodzcore.Models;

namespace foodzcore.Services.RecipeServices
{
    public class RecipeDeleteService
    {
        private readonly foodzcoreEFDBContext _context;

        public RecipeDeleteService(foodzcoreEFDBContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteRecipeAsync(int recipeId)
        {

            var recipeToDelete = await _context.Recipes.FindAsync(recipeId);

            if (recipeToDelete != null)
            {
                _context.Recipes.Remove(recipeToDelete);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;

        }
    }
}
