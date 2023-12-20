using foodzcore.Data;
using foodzcore.Models;
using Microsoft.AspNetCore.Hosting;

namespace foodzcore.Services.RecipeServices
{
    public class RecipeCreateService
    {
        private readonly foodzcoreEFDBContext _context;

        public RecipeCreateService(foodzcoreEFDBContext context)
        {
            _context = context;
        }

        public async Task<Recipe> RecipeCreateAsync(string recipeName, string description, decimal price, int difficultyRating, int timeRating)
        {

            var newRecipe = new Recipe
            {
                RecipeName = recipeName,
                //Image = defaultImage,
                Description = description,
                Price = price,
                DifficultyRating = difficultyRating,
                TimeRating = timeRating
            };

            _context.Recipes.Add(newRecipe);
            await _context.SaveChangesAsync();

            return newRecipe;
        }
    }
}
