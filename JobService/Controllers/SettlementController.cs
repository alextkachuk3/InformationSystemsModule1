using Microsoft.AspNetCore.Mvc;

namespace JobService.Controllers
{
    public class SettlementController : Controller
    {
        [HttpPost]
        public JsonResult GetRegionSettlements(int regionId)
        {
            return new JsonResult(Ok(new List<int> { 3, 4, 5 }));
        }
    }
}
