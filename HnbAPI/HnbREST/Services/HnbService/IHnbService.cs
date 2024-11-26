using HnbREST.Models;

namespace HnbREST.Services.HnbService
{
    public interface IHnbService
    {
        Task<List<ViewResultModel>> GetTasksAsync(DateTime dateFrom, DateTime dateTo);
    }
}