using Grocery_Management_Application.ViewModel.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Grocery_Management_Application.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            var user = await _userManager.FindByNameAsync(registerViewModel.Email);

            if(user != null)
            {
                ModelState.AddModelError("" ,$" User with Email {registerViewModel.Email} already exsist");
                return View(registerViewModel);
            }
            else
            {
                var identityuser = new IdentityUser
                {
                    UserName = registerViewModel.Email,
                    Email = registerViewModel.Email
                };
                 
                var result = await _userManager.CreateAsync(identityuser, registerViewModel.Password);

                if(result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);    
                    }
                }
            }
            return View(registerViewModel);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, false, false);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Grocery");
                }
                ModelState.AddModelError("", "Invalid credentials!");
            }
            return View(loginViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login","Account");
        }
    }
}
