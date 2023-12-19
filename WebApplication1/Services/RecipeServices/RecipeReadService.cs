using foodzcore.Data;
using foodzcore.Models;

namespace foodzcore.Services.RecipeServices
{
    public class RecipeReadService
    {
        private readonly foodzcoreEFDBContext _context;

        public RecipeReadService(foodzcoreEFDBContext context)
        {
            _context = context;
        }

        public List<Recipe> GetAllRecipes()
        {
            // Retrieve all recipes from the database and puts them in a List
            return _context.Recipes.ToList();
        }

        public Recipe GetSpecificRecipe(int id)
        {
            foreach (Recipe recipeitem in _context.Recipes)
            {
                if (recipeitem.RecipeID == id)
                    return recipeitem;
            }

            return null;
        }
    }
}
