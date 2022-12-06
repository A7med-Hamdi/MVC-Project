using Microsoft.AspNetCore.Mvc;
using ProjectLapDay2.Models;

namespace ProjectLapDay2.Controllers
{
    public class LoginController : Controller
    {
        Day2DBContext context = new Day2DBContext();
        public IActionResult Index()
        {
            return View();
        }

      
        public IActionResult loginForm()
        {
            return View();

        }

        public IActionResult submitLogin(login _login)
        {
            login login = context.logins.FirstOrDefault(c => c.UserName == _login.UserName && c.Password == _login.Password);
            if (login != null)
            {
                HttpContext.Session.SetString("name", login.UserName);
                return RedirectToAction("getAll", "Employee");

            }else
            {
                return View("loginForm");

            }

        }
    }
}
