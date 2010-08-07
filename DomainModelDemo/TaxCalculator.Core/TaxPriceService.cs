using System;

namespace TaxCalculator.Core
{
    public class TaxPriceService : ITaxPriceService
    {
        public decimal CalculateAfterTaxPrice(IProduct product)
        {
            var levier = new LevierFactory().GenerateLevier(product);
            return levier.Tax() + product.Price;
        }

        public decimal CalculateTax(IProduct product)
        {
            var levier = new LevierFactory().GenerateLevier(product);
            return levier.Tax();
        }
    }
}