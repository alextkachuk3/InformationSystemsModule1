using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using JobService.Data;
using JobService.Services.UserService;
using JobService.Models;

namespace JobService.Controllers
{
    public class EmployerController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public EmployerController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            if (HttpContext.Request.Cookies.ContainsKey("mode"))
            {
                string mode = HttpContext.Request.Cookies["mode"]!;

                if (mode.Equals("jobseeker"))
                {
                    ViewBag.Mode = "jobseeker";
                }
                else if (mode.Equals("employer"))
                {
                    ViewBag.Mode = "employer";
                }
            }
            else
            {
                HttpContext.Response.Cookies.Append("mode", "employer");
                ViewBag.Mode = "employer";
            }
            return View();
        }

        public IActionResult AddVacancy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddVacancy(string title, string description)
        {
            return View();
        }

        public IActionResult ToJobseekerMode()
        {
            HttpContext.Response.Cookies.Append("mode", "jobseeker");
            return LocalRedirect("~/");
        }

    }
}
