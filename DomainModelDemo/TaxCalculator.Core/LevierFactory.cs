namespace TaxCalculator.Core
{
    public class LevierFactory
    {
        public Levier GenerateLevier(ISaleItem saleItem)
        {
            var levier = new Levier {BeforeTaxAmount = saleItem.Price};

            if(saleItem.BasicDutyType != null)
                levier.AddTaxCalculater(new TaxCalculater(saleItem.BasicDutyType.TaxRate, new TaxRounder()));

            if (saleItem.IsImported)
                levier.AddTaxCalculater(new CommonsTaxCalculater(new TaxRounder()));

            return levier;
        }
    }
}