using foodzcore.Services.LoginServices;
using foodzcore.Services.AccountServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using foodzcore.Models;

namespace foodzcore.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly foodzcoreAuthenticationService _authService;
        private readonly AccountReadService _accountReadService;

        public LoginModel(foodzcoreAuthenticationService authService, AccountReadService accountReadService)
        {
            _authService = authService;
            _accountReadService = accountReadService;
        }

        [BindProperty]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public static Account LoggedInUser { get; set; }

        public async Task<IActionResult> OnPost()
        {
            //Login Logic
            if (ModelState.IsValid)
            {
                // Checks if the provided username and password match a user in the database
                var isAuthenticated = _authService.AuthenticateUser(Username, Password);

                if (isAuthenticated)
                {
                    // Attaches the logged in User with the relevant username and password to be used on their personal profile page and displaying their username in the navigation bar
                    LoggedInUser = _accountReadService.GetUserByUsernameAndPassword(Username, Password);

                    //var claims = new List<Claim> { new Claim(ClaimTypes.Name, Username) };
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, Username),
                        new Claim("UserID", LoggedInUser.UserID.ToString()) // Ensure this claim is set
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    // Redirect to a success page or perform other actions
                    return RedirectToPage("/Profile/UserProfile");
                }
                else
                {
                    // Authentication failed, add a model error
                    ModelState.AddModelError(string.Empty, "Invalid username or password");
                }
            }

            // If the model state is not valid, return to the login page with validation errors
            return Page();
        }
    }
}
