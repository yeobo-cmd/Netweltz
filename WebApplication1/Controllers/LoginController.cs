using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class LoginController1 : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public List<Usermodel> PutValue()
        {
            var users = new List<Usermodel>
            {
                new Usermodel { Id = 1, username = "admin", password = "admin123" } 
            };
            return users;
        }

        [HttpPost]
        public IActionResult Verify(Usermodel user)
        {
            var u = PutValue();
            var un= u.Where(u=>u.username.Equals(user.username));
            var userpassword = u.Where(u => u.password.Equals(user.password));
            if (userpassword.Count() == 1)
            {
                ViewBag.message = "Login Success";
                return View("LoginSuccess");
            } 
            else
            {
                ViewBag.message = "Login Failed";
                return View("Login");
            }
        }
     }
}
