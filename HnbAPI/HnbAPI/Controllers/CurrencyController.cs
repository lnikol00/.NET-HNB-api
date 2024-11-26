using HnbAPI.Controllers.DTO;
using HnbAPI.Services.HnbService;
using HnbAPI.Services.HnbService.Model;
using Microsoft.AspNetCore.Mvc;

namespace HnbAPI.Controllers
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
        public async Task<ActionResult<ViewResultModel>> GetCurrencies([FromQuery] SearchRequestDTO date)
        {
            var list = await _hnbService.GetHnbValues(date);
            return Ok(list);
        }
    }
}
