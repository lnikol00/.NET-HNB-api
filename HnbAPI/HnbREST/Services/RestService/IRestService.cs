using HnbREST.Models;

namespace HnbREST.Services.RestService
{
    public interface IRestService
    {
        Task<List<ViewResultModel>> GetCurrenciesAsync(DateTime fromDate, DateTime toDate);
    }
}