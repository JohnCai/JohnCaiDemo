namespace TaxCalculator.Core
{
    public interface ITaxPriceService
    {
        decimal CalculateAfterTaxPrice(ISaleItem saleItem);

        decimal CalculateTax(ISaleItem saleItem);
    }
}