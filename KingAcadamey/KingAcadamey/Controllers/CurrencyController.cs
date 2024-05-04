using KingAcadamey.Services.HnbService;
using KingAcadamey.Services.HnbService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KingAcadamey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly IHnbService _hnbService;

        public CurrencyController(IHnbService hnbService)
        {
            _hnbService = hnbService;
        }

        [HttpGet]
        public ActionResult<ViewResultModel> GetCurrencies([FromQuery] string fromDate, [FromQuery] string toDate)
        {
            var list = _hnbService.GetHnbValues(fromDate, toDate);
            return Ok(list);
        }
    }
}
