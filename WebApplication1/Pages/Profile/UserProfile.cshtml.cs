using foodzcore.Data;
using foodzcore.Models;
using foodzcore.Pages.Login;
using foodzcore.Services.AccountServices;
using foodzcore.Services.RecipeServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace foodzcore.Pages.Profile
{
    public class UserProfileModel : PageModel
    {
        private readonly foodzcoreEFDBContext _context;
        private readonly AccountDeleteService _accountDeleteService;
        private readonly AccountUpdateService _accountUpdateService;

        public UserProfileModel(foodzcoreEFDBContext context, AccountDeleteService accountDeleteService, AccountUpdateService accountUpdateService)
        {
            _context = context;
            _accountDeleteService = accountDeleteService;
            _accountUpdateService = accountUpdateService;
        }

        public Account ActiveUser { get; set; }

        public void OnGetAsync()
        {
            // Retrieves the logged-in user information from LoginModel
            ActiveUser = LoginModel.LoggedInUser;

            // Set the page title to the active user's username
            ViewData["Title"] = $"User Profile - {ActiveUser?.Username}";

            //ActiveUser = await _context.Recipes.FirstOrDefaultAsync(m => m.UserID == id);
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var deleteResult = await _accountDeleteService.DeleteAccountAsync(id);

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
