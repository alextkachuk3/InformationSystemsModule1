using Microsoft.AspNetCore.Mvc;

namespace JobService.Controllers
{
    public class AuthorizeController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
    }
}
