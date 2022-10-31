using JobService.Services.SettlementService;
using Microsoft.AspNetCore.Mvc;

namespace JobService.Controllers
{
    public class SettlementController : Controller
    {
        private readonly ILogger<SettlementController> _logger;
        private readonly ISettlementService _settlementService;

        public SettlementController(ILogger<SettlementController> logger, ISettlementService settlementService)
        {
            _logger = logger;
            _settlementService = settlementService;
        }

        [HttpPost]
        public JsonResult GetRegionSettlements(int regionId)
        {
            var settlements = _settlementService.GetRegionSettlementsList(regionId);
            return new JsonResult(Ok(settlements));
        }
    }
}
