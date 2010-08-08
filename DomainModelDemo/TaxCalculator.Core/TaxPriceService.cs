using System;

namespace TaxCalculator.Core
{
    public class TaxPriceService : ITaxPriceService
    {
        public decimal CalculateAfterTaxPrice(ISaleItem saleItem)
        {
            var levier = new LevierFactory().GenerateLevier(saleItem);
            return levier.Tax() + saleItem.Price;
        }

        public decimal CalculateTax(ISaleItem saleItem)
        {
            var levier = new LevierFactory().GenerateLevier(saleItem);
            return levier.Tax();
        }
    }
}