namespace KingAcadamey.Services.ArithmeticMeanService
{
    public class ArithemticMeanService : IArithemticMeanService
    {
        public double CalculateArithmeticMean(List<double> values)
        {
            double mean = values.Average();

            return mean;
        }
    }
}