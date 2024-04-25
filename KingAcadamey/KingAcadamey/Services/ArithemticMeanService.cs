namespace KingAcadamey.Services
{
    public class ArithemticMeanService : IArithemticMeanService
    {
        public decimal CalculateArithmeticMean(List<decimal> values)
        {
            if (values == null || values.Count == 0) return 0;

            decimal sum = 0;
            foreach (var value in values)
            {
                sum += value;
            }

            return sum / values.Count;
        }
    }
}
