using KingAcadamey.Services;
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
        public IActionResult GetCurrencies([FromQuery] string fromDate, [FromQuery] string toDate)
        {
            var list = _hnbService.GetHnbValues(fromDate, toDate);
            return Ok(list);
        }
    }
}
