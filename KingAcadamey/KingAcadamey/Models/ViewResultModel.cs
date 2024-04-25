namespace KingAcadamey.Models
{
    public class ViewResultModel
    {
        public CurrencyModel? CurrencyModel { get; set; }    
        public string? Message { get; set; }
    }

    public class CurrencyModel
    {
        public decimal ProsjekSrednjiTecaj { get; set; }
        public decimal ProsjekProdajniTecaj { get; set; }
        public decimal ProsjekKupovniTecaj { get; set; }
    }
}
