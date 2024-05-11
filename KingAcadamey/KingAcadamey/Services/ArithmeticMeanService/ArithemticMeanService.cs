namespace KingAcadamey.Services.ArithmeticMeanService
{
    public class ArithemticMeanService : IArithemticMeanService
    {
        public decimal CalculateArithmeticMean(List<decimal> values)
        {
            decimal mean = values.Average();

            return mean;
        }
    }
}