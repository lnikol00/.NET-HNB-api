using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HnbREST.Models
{
    public class ViewResultModel
    {
        public string? Country { get; set; }
        public string? CurrencyCode { get; set; }
        public decimal ProsjekSrednjiTecaj { get; set; }
        public decimal ProsjekProdajniTecaj { get; set; }
        public decimal ProsjekKupovniTecaj { get; set; }
    }
}
