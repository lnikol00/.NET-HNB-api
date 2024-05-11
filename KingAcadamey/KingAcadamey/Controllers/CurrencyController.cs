using KingAcadamey.Services.HnbService;
using KingAcadamey.Services.HnbService.Model;
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
        public async Task<ActionResult<ViewResultModel>> GetCurrencies([FromQuery] string fromDate, [FromQuery] string toDate)
        {
            var list = await _hnbService.GetHnbValues(fromDate, toDate);
            return Ok(list);
        }
    }
}
