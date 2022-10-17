using Microsoft.AspNetCore.Mvc;

namespace JobService.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
