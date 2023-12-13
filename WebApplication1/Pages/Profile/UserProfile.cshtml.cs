using foodzcore.Models;
using foodzcore.Pages.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace foodzcore.Pages.Profile
{
    public class UserProfileModel : PageModel
    {
        public Account ActiveUser { get; set; }

        public void OnGet()
        {
            // Retrieve the logged-in user information from LoginModel
            ActiveUser = LoginModel.LoggedInUser;

            // Set the page title to the active user's username
            ViewData["Title"] = $"User Profile - {ActiveUser?.Username}";
        }
    }
}
