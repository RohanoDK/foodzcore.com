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

        public RegisterModel(AccountCreateService accountCreateService)
        {
            _accountCreateService = accountCreateService;
        }

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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _accountCreateService.CreateAccountAsync(Username, Password, Email, IsAdmin);

            return RedirectToPage("/Index");
        }
    }
}
