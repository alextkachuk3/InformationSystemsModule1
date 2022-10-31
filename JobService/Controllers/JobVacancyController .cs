using JobService.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JobService.Controllers
{
    public class JobVacancyController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public JobVacancyController(ILogger<HomeController> logger)
        {
            _logger = logger;
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
                HttpContext.Response.Cookies.Append("mode", "jobseeker");
                ViewBag.Mode = "jobseeker";
            }

            return View();
        }
    }
}