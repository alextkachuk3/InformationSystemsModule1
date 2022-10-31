using JobService.Models;
using JobService.Services.SettlementService;
using JobService.Services.VacancyService;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;

namespace JobService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISettlementService _settlementService;
        private readonly IVacancyService _vacancyService;

        public HomeController(ILogger<HomeController> logger, ISettlementService settlementService, IVacancyService vacancyService)
        {
            _logger = logger;
            _settlementService = settlementService;
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
                    return LocalRedirect("~/employer");
                }
            }
            else
            {
                HttpContext.Response.Cookies.Append("mode", "jobseeker");
                ViewBag.Mode = "jobseeker";
            }

            var regions = _settlementService.GetRegionsList();

            return View(regions);
        }


        public IActionResult ToEmployerMode()
        {
            HttpContext.Response.Cookies.Append("mode", "employer");
            return LocalRedirect("~/employer");
        }

        [HttpPost]
        public IActionResult Index(string? searchWord, int? settlementId)
        {
            return RedirectToAction("Search", "JobVacancy", new { searchWord, settlementId });
        }

        //[HttpPost]
        //public IActionResult Search(string? searchWord, int? settlementId)
        //{
        //    return View(_vacancyService.SearchJobVacancies(searchWord, settlementId));
        //}

        //[HttpPost]
        //public IActionResult Index(string? searchWord, string? settlementId)
        //{
        //    return LocalRedirect("~/jobvacancy/search?searchWord=" + searchWord + "&settlementId=" + settlementId);
        //}

    }
}