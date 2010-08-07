namespace TaxCalculator.Core
{
    public class LevierFactory
    {
        public Levier GenerateLevier(Product product)
        {
            var levier = new Levier {BeforeTaxAmount = product.Price};

            if(product.BasicDutyType != null)
                levier.AddTaxCalculater(new TaxCalculater(product.BasicDutyType.TaxRate, new TaxRounder()));

            if (product.IsImported)
                levier.AddTaxCalculater(new CommonsTaxCalculater(new TaxRounder()));

            return levier;
        }
    }
}