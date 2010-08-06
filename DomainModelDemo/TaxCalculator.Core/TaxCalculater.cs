using TaxCalculator.Core.DataInterfaces;

namespace TaxCalculator.Core
{
    public class TaxCalculater : ITaxCalculater
    {
        public TaxCalculater(double taxRate, ITaxRounder taxRounder)
        {
            TaxRate = taxRate;
            TaxRounder = taxRounder;
        }

        protected ITaxRounder TaxRounder { get; set; }

        protected double TaxRate { get; private set; }

        public decimal CalculateTax(decimal preTaxPrice)
        {
            decimal tax = TaxRounder.Round(preTaxPrice * (decimal) TaxRate);
            return tax;
        }
    }
}