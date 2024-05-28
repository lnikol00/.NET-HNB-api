using KingAcadamey.Controllers.DTO;
using KingAcadamey.Services.HnbService.Model;

namespace KingAcadamey.Services.HnbService
{
    public interface IHnbService
    {
        Task<List<ViewResultModel>> GetHnbValues(SearchRequestDTO date);
    }
}