using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using JobService.Data;
using JobService.Services.UserService;

namespace JobService.Controllers
{
    public class AuthorizationController : Controller
    {
        private readonly IUserService _userService;

        public AuthorizationController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            bool authSuccess = true;
            if (authSuccess)
            {
                var claims = new List<Claim>();

                claims.Add(new Claim(ClaimTypes.Name, username));

                if (username == "admin")
                {
                    claims.Add(new Claim(ClaimTypes.Role, "admin"));
                }
                else
                {
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
        public IActionResult SignUp(string username, string password, string firstName, string lastName)
        {
            if(_userService.IsUserNameUsed(username))
            {
                ViewBag.AuthError = "Username already used!";
                return View();
            }
            else 
            {
                _userService.AddUser(username, password, firstName, lastName);
                return Login(username, password);
            }
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return LocalRedirect("~/");
        }
    }
}
