using KingAcadamey.Models;

namespace KingAcadamey.Services
{
    public interface IHnbService
    {
        Task<List<ViewResultModel>> GetHnbValues(string dateFrom, string dateTo);
    }
}