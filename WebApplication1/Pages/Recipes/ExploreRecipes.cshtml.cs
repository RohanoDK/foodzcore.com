using System.Collections.Generic;
using foodzcore.Models;
using foodzcore.Services.RecipeServices;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace foodzcore.Pages.Recipes
{
    public class ExploreRecipesModel : PageModel
    {
        private readonly RecipeReadService _recipeReadService;

        public ExploreRecipesModel(RecipeReadService recipeExploreService)
        {
            _recipeReadService = recipeExploreService;
        }

        public List<Recipe> Recipes { get; set; }

        public void OnGet()
        {
            Recipes = _recipeReadService.GetAllRecipes();
        }
    }
}