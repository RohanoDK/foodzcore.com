using foodzcore.Data;
using foodzcore.Models;
using foodzcore.Services.RecipeServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace foodzcore.Pages.Recipes
{
    public class RecipeDetailsModel : PageModel
    {
        private readonly foodzcoreEFDBContext _context;
        private readonly RecipeDeleteService _recipeDeleteService;
        private readonly RecipeUpdateService _recipeUpdateService;

        public RecipeDetailsModel(foodzcoreEFDBContext context, RecipeDeleteService recipeDeleteService, RecipeUpdateService recipeUpdateService)
        {
            _context = context;
            _recipeDeleteService = recipeDeleteService;
            _recipeUpdateService = recipeUpdateService;
        }

        public Recipe Recipe { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Recipe = await _context.Recipes.FirstOrDefaultAsync(m => m.RecipeID == id);

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var deleteResult = await _recipeDeleteService.DeleteRecipeAsync(id);

            if (deleteResult)
            {
                // Redirect to a page or take appropriate action after successful deletion
                return RedirectToPage("/Index");
            }
            else
            {
                // Handle the case where deletion failed
                // You may want to display an error message or redirect to an error page
                return Page();
            }
        }
    }
}
