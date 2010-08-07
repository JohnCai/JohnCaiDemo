using TaxCalculator.Core.DataInterfaces;

namespace TaxCalculator.Core
{
    public class CommonsTaxCalculater : TaxCalculater
    {
        private const double Rate = 0.05;

        public CommonsTaxCalculater(ITaxRounder taxRounder) : base(Rate, taxRounder)
        {
        }
    }
}