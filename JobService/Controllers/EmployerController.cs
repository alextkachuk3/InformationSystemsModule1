using Microsoft.AspNetCore.Mvc;
using JobService.Services.VacancyService;
using Microsoft.AspNetCore.Authorization;

namespace JobService.Controllers
{
    public class EmployerController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVacancyService _vacancyService;

        public EmployerController(ILogger<HomeController> logger, IVacancyService vacancyService)
        {
            _logger = logger;
            _vacancyService = vacancyService;
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

        [Authorize]
        [HttpPost]
        public IActionResult AddVacancy(string title, string salary, string description)
        {
            var user = HttpContext.User.Identity;
            
            _vacancyService.AddVacancy(user!.Name!, title, int.Parse(salary), description);
            return LocalRedirect("~/employer");
        }

        public IActionResult ToJobseekerMode()
        {
            HttpContext.Response.Cookies.Append("mode", "jobseeker");
            return LocalRedirect("~/");
        }

    }
}
