namespace TaxCalculator.Core
{
    public interface ITaxCalculater
    {
        decimal CalculateTax(decimal preTaxPrice);
    }
}