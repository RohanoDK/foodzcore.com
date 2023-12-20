using foodzcore.Data;
using foodzcore.Models;
using foodzcore.Pages.Login;
using foodzcore.Services.AccountServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace foodzcore.Pages.Profile
{
    public class UserProfileModel : PageModel
    {
        private readonly foodzcoreEFDBContext _context;
        private readonly AccountDeleteService _accountDeleteService;
        private readonly AccountUpdateService _accountUpdateService;
        private readonly AccountReadService _accountReadService;

        public UserProfileModel(foodzcoreEFDBContext context, AccountDeleteService accountDeleteService, AccountUpdateService accountUpdateService, AccountReadService accountReadService)
        {
            _context = context;
            _accountDeleteService = accountDeleteService;
            _accountUpdateService = accountUpdateService;
            _accountReadService = accountReadService;
        }

        public Account ActiveUser { get; set; }

        public void OnGet()
        {
            // Retrieves the logged-in user information from LoginModel
            ActiveUser = LoginModel.LoggedInUser;

            // Set the page title to the active user's username
            ViewData["Title"] = $"User Profile - {ActiveUser?.Username}";
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var deleteResult = await _accountDeleteService.DeleteAccountAsync(id);

            if (deleteResult)
            {
                // Runs the logout procedure
                LoginModel.LoggedInUser = null;

                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToPage("/index");

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
