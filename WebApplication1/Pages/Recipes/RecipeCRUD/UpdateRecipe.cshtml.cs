using foodzcore.Services.RecipeServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace foodzcore.Pages.Recipes.RecipeCRUD
{
    public class UpdateRecipeModel : PageModel
    {
        private readonly RecipeUpdateService _recipeUpdateService;
        private readonly RecipeReadService _recipeReadService;

        public UpdateRecipeModel(RecipeUpdateService recipeUpdateService, RecipeReadService recipeReadService)
        {
            _recipeUpdateService = recipeUpdateService;
            _recipeReadService = recipeReadService;
        }

        [BindProperty]
        public Models.Recipe RecipeItem { get; set; }


        public async Task<IActionResult> OnGetAsync(int id)
        {
            RecipeItem = _recipeReadService.GetSpecificRecipe(id);
            return Page();
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var updateResult = await _recipeUpdateService.UpdateRecipeAsync(RecipeItem);

            if (updateResult)
            {
                return RedirectToPage("/Recipes/ExploreRecipes");
            }
            else
            {
                return Page();
            }
        }
    }
}

