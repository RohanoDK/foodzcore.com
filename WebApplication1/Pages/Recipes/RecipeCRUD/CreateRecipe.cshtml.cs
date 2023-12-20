using foodzcore.Models;
using foodzcore.Services.RecipeServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace foodzcore.Pages.Recipes.RecipeCRUD
{
    public class CreateRecipeModel : PageModel
    {
        // Dependency Injection
        private readonly RecipeCreateService _recipeCreateService;

        // Model Constructor
        public CreateRecipeModel(RecipeCreateService recipeCreateService)
        {
            _recipeCreateService = recipeCreateService;
        }

        [BindProperty]
        [Required(ErrorMessage = "RecipeName is required")]
        public string RecipeName { get; set; }

        //[BindProperty]
        //public string Image { get; set; }

        [BindProperty]
        public string Description { get; set; }

        [BindProperty]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        public decimal Price { get; set; }

        [BindProperty]
        [Range(1, 5, ErrorMessage = "DifficultyRating must be between 1 and 5")]
        public int DifficultyRating { get; set; }

        [BindProperty]
        [Range(1, 10, ErrorMessage = "TimeRating must be between 1 and 10")]
        public int TimeRating { get; set; }


        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                // Log ModelState errors for debugging
                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine($"Model Error: {error.ErrorMessage}");
                    }
                }

                return Page();
            }

            await _recipeCreateService.RecipeCreateAsync(RecipeName, Description, Price, DifficultyRating, TimeRating);

            return RedirectToPage("/Recipes/ExploreRecipes");
        }
    }
}
