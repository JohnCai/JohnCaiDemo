namespace TaxCalculator.Core
{
    public interface ITaxPriceService
    {
        decimal CalculateAfterTaxPrice(IProduct product);

        decimal CalculateTax(IProduct product);
    }
}