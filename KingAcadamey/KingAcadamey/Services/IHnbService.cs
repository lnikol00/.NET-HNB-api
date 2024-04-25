using KingAcadamey.Models;

namespace KingAcadamey.Services
{
    public interface IHnbService
    {
        Task<ViewResultModel> GetHnbValues(string dateFrom, string dateTo);
    }
}