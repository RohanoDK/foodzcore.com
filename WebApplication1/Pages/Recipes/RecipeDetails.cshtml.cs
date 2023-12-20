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

        public RecipeDetailsModel(foodzcoreEFDBContext context, RecipeDeleteService recipeDeleteService)
        {
            _context = context;
            _recipeDeleteService = recipeDeleteService;
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
                return RedirectToPage("/Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
