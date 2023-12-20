using Azure.Identity;
using foodzcore.Models;
using foodzcore.Pages.Login;
using foodzcore.Services.AccountServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace foodzcore.Pages.Profile
{
    public class UpdateAccountModel : PageModel
    {
        private readonly AccountUpdateService _accountUpdateService;

        public UpdateAccountModel(AccountUpdateService accountUpdateService)
        {
            _accountUpdateService = accountUpdateService;
        }

        public Account AccountItem { get; set; }

        //[BindProperty]
        //public string Username { get; set; }

        //[BindProperty]
        //public string Email { get; set; }


        //[BindProperty]
        //public Account ActiveUser { get; set; }


        public void OnGet()
        {
            // Retrieves the logged-in user information from LoginModel
            AccountItem = LoginModel.LoggedInUser;
            Console.WriteLine(AccountItem.Username);
            Console.WriteLine(AccountItem.Email);
            Console.WriteLine(AccountItem.UserID);
            Console.WriteLine(AccountItem.Password);
            Console.WriteLine(AccountItem.ConfirmPassword);
        }


        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model State Errors:");

                foreach (var modelState in ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                        Console.WriteLine($"- {error.ErrorMessage}");
                    }
                }
                Console.WriteLine(AccountItem.Username);
                Console.WriteLine(AccountItem.Email);
                Console.WriteLine(AccountItem.UserID);
                Console.WriteLine(AccountItem.Password);
                Console.WriteLine(AccountItem.ConfirmPassword);
                Console.WriteLine("NOPE");
                return Page();
            }

            Console.WriteLine(AccountItem.Username);
            Console.WriteLine(AccountItem.Email);
            Console.WriteLine(AccountItem.UserID);
            Console.WriteLine(AccountItem.Password);
            Console.WriteLine(AccountItem.ConfirmPassword);
            Console.WriteLine("YEAH");

            var updateResult = await _accountUpdateService.UpdateAccountAsync(AccountItem);

            if (updateResult)
            {
                // Redirect to the Userprofile details page after successful update
                return RedirectToPage("/UserProfile");
            }
            else
            {
                // Update Failed, return to same page
                return Page();
            }

        }
    }
}

