using Microsoft.AspNetCore.Mvc;
using StolenBlog.Models;

namespace StolenBlog.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Login(Login model)
        {
            return this.View(model);
        }

        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(Register model)
        {
            return this.View(model);
        }
    }
}
