using HnbAPI.Controllers.DTO;
using HnbAPI.Services.HnbService.Model;

namespace HnbAPI.Services.HnbService
{
    public interface IHnbService
    {
        Task<List<ViewResultModel>> GetHnbValues(SearchRequestDTO date);
    }
}