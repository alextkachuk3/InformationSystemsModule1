using Microsoft.AspNetCore.Mvc;
using JobService.Services.VacancyService;
using Microsoft.AspNetCore.Authorization;
using JobService.Services.SettlementService;

namespace JobService.Controllers
{
    public class EmployerController : Controller
    {
        private readonly ILogger<EmployerController> _logger;
        private readonly IVacancyService _vacancyService;
        private readonly ISettlementService _settlementService;

        public EmployerController(ILogger<EmployerController> logger, IVacancyService vacancyService, ISettlementService settlementService)
        {
            _logger = logger;
            _vacancyService = vacancyService;
            _settlementService = settlementService;
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
            var regions = _settlementService.GetRegionsList();
            return View(regions);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddVacancy(string title, int? settlementId, string salary, string description)
        {
            var user = HttpContext.User.Identity;

            _vacancyService.AddVacancy(user!.Name!, title, settlementId, int.Parse(salary), description);
            return LocalRedirect("~/employer");
        }

        public IActionResult ToJobseekerMode()
        {
            HttpContext.Response.Cookies.Append("mode", "jobseeker");
            return LocalRedirect("~/");
        }

    }
}
