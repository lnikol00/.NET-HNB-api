using HnbAPI.Controllers.DTO;
using HnbAPI.Exceptions;
using HnbAPI.Models;
using HnbAPI.Services.HnbService.Model;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace HnbAPI.Services.HnbService
{
    public class HnbService : IHnbService
    {
        private readonly IOptions<ConnectionApi> _connectionApi;

        public HnbService(IOptions<ConnectionApi> connectionApi)
        {
            _connectionApi = connectionApi;
        }

        private decimal CalculateArithmeticMean(List<decimal> values)
        {
            decimal mean = values.Average();

            return mean;
        }

        public async Task<List<ViewResultModel>> GetHnbValues(SearchRequestDTO date)
        {
            string url = _connectionApi.Value.ConnectionString;

            url = url.Replace("dateFrom", date.fromDate);
            url = url.Replace("dateTo", date.toDate);


            var client = new HttpClient();
            var request = new List<ViewResultModel>();
            try
            {
                var response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var reposnseContext = await response.Content.ReadAsStringAsync();

                    if (!string.IsNullOrEmpty(reposnseContext))
                    {
                        var results = new List<SearchResultModel>();

                        results = JsonSerializer.Deserialize<List<SearchResultModel>>(reposnseContext);

                        if (results != null && results.Count != 0)
                        {
                            var currencies = results.Select(x => new HnbCurrency
                            {
                                BrojTecajnice = x.broj_tecajnice,
                                DatumPrimjene = DateTime.Parse(x.datum_primjene),
                                Drzava = x.drzava,
                                DrzavaIso = x.drzava_iso,
                                KupovniTecaj = decimal.Parse(x.kupovni_tecaj),
                                ProdajniTecaj = decimal.Parse(x.prodajni_tecaj),
                                SifraValute = x.sifra_valute,
                                SrednjiTecaj = decimal.Parse(x.srednji_tecaj),
                                Valuta = x.valuta

                            }).ToList();

                            if (currencies != null)
                            {
                                var groupedCurrencies = currencies
                                    .GroupBy(x => x.Valuta)
                                    .ToList();

                                foreach (var currency in groupedCurrencies)
                                {
                                    var TecajKupovni = currency.Select(x => x.KupovniTecaj).ToList();
                                    var prosjekKupovniTecaj = Math.Round(CalculateArithmeticMean(TecajKupovni), 5);
                                    var TecajProdajni = currency.Select(x => x.ProdajniTecaj).ToList();
                                    var prosjekProdajniTecaj = Math.Round(CalculateArithmeticMean(TecajProdajni), 5);
                                    var TecajSrednji = currency.Select(x => x.SrednjiTecaj).ToList();
                                    var prosjekSrednjiTecaj = Math.Round(CalculateArithmeticMean(TecajSrednji), 5);

                                    var country = currency.First().Drzava;

                                    var model = new ViewResultModel
                                    {
                                        Country = country,
                                        CurrencyCode = currency.Key.ToString(),
                                        ProsjekKupovniTecaj = prosjekKupovniTecaj,
                                        ProsjekSrednjiTecaj = prosjekSrednjiTecaj,
                                        ProsjekProdajniTecaj = prosjekProdajniTecaj
                                    };
                                    request.Add(model);
                                }
                            }
                        }
                        else
                        {
                            throw new ErrorMessage("No results to match this parameters");
                        }

                    }
                    else
                    {
                        throw new ErrorMessage("Invalid response context!");
                    }

                }
                else
                {
                    throw new ErrorMessage("No response!");
                }
            }
            catch (Exception ex)
            {
                throw new ErrorMessage($"An error occurred: {ex.Message}");
            }

            return request;
        }
    }
}
