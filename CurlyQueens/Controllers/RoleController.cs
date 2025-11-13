using CurlyQueens.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CurlyQueens.Controllers
{
   // [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> RoleManager)
        {
            this._roleManager = RoleManager;
        }
        [HttpGet]
        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> New(RoleViewModel roleVM )
        {
            if (ModelState.IsValid)
            {
                IdentityRole roleModel=new IdentityRole()
                {
                    Name=roleVM.RoleName
                };
                IdentityResult result= await _roleManager.CreateAsync(roleModel);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", result.Errors.FirstOrDefault().Description);
                }
            }
            return View(roleVM);
        }
    }
}
