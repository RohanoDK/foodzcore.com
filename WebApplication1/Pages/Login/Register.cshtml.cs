using foodzcore.Services.AccountServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace foodzcore.Pages.Login
{
    public class RegisterModel : PageModel
    {
        // Dependency Injection
        private readonly AccountCreateService _accountCreateService;

        //Model Constructor
        public RegisterModel(AccountCreateService accountCreateService)
        {
            _accountCreateService = accountCreateService;
        }

        // Add properties for user registration fields
        [BindProperty]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d).{6,}$", ErrorMessage = "Password must be at least 6 characters long and include at least one letter and one number")]
        public string Password { get; set; }

        [BindProperty]
        [Compare("Password", ErrorMessage = "Passwwords do not match")]
        public string ConfirmPassword { get; set; }

        [BindProperty]
        public bool IsAdmin { get; set; }

        [BindProperty]
        public string Email { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            // Checks for valid ModelState - Checks Bound properties submitted info
            if (!ModelState.IsValid)
            {
                // Return the page with validation errors if the model is not valid
                return Page();
            }

            // Creates a newAccount that stores the details provided in the parameters, and stores it in the database
            await _accountCreateService.CreateAccountAsync(Username, Password, Email, IsAdmin);

            // Your registration logic here, create a user account
            // Use the values of properties like Username, Password, Email, and IsAdmin

            // Redirect to a confirmation page or another appropriate action
            return RedirectToPage("/Index");
        }
    }
}
