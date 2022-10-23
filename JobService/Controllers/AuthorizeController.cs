using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace JobService.Controllers
{
    public class AuthorizeController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string login, string password)
        {
            bool authSuccess = true;
            if (authSuccess)
            {
                var claims = new List<Claim>();

                if (login == "admin")
                {
                    claims.Add(new Claim(ClaimTypes.Name, login));
                    claims.Add(new Claim(ClaimTypes.Role, "admin"));
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Name, login));
                    claims.Add(new Claim(ClaimTypes.Role, "user"));
                }

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                return LocalRedirect("~/");
            }
            else
            {
                ViewBag.AuthError = "Wrong login or password!";
                return View();
            }
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(string login, string password)
        {
            return LocalRedirect("~/");
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return LocalRedirect("~/");
        }
    }
}
