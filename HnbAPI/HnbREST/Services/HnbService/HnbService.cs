using HnbREST.Models;
using HnbREST.Services.RestService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HnbREST.Services.HnbService
{
    public class HnbService : IHnbService
    {
        IRestService _restService;

        public HnbService(IRestService restService)
        {
            _restService = restService;
        }

        public Task<List<ViewResultModel>> GetTasksAsync(DateTime dateFrom, DateTime dateTo)
        {
            return _restService.GetCurrenciesAsync(dateFrom, dateTo);
        }
    }
}
