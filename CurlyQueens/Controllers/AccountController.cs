using CurlyQueens.Data;
using CurlyQueens.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace CurlyQueens.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel user)
        {
            if (ModelState.IsValid) 
            {
                ApplicationUser userModel=  new ApplicationUser()
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    PasswordHash=user.Password
                };
                IdentityResult result = await _userManager.CreateAsync(userModel, user.Password);
                if (result.Succeeded) 
                {
                   //await _userManager.AddToRoleAsync(userModel,"Admin");
                    await _userManager.AddToRoleAsync(userModel,"User");
                    await _signInManager.SignInAsync(userModel,false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var errorItem in result.Errors)
                {
                    ModelState.AddModelError("", errorItem.Description);
                }
            }
            return View("Register",user);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel user)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser userModel = await _userManager.FindByNameAsync(user.UserName);
                if(userModel !=null)
                {
                    bool found = await _userManager.CheckPasswordAsync(userModel, user.Password);
                    if (found)
                    {
                        await _signInManager.SignInAsync(userModel, false);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "Invalid Account");   
            }
            return View("Login", user);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
