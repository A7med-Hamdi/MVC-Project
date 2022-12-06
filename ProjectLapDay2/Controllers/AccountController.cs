using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectLapDay2.Models;

namespace ProjectLapDay2.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser>  userManager ,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RrgisteruserVM newuserVM)
        {
            if (ModelState.IsValid)
            {
                //create user
                ApplicationUser user = new ApplicationUser();
                user.address = newuserVM.Address;
                user.UserName = newuserVM.username;
                user.PasswordHash = newuserVM.password;

             IdentityResult result= await  userManager.CreateAsync(user);
                if (result.Succeeded == true)
                {
                    //create cookie

                }
                else
                {
                   foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }
            return View(newuserVM);
        }
    }
}
