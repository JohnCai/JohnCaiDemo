using NUnit.Framework;
using TaxCalculator.Core;

namespace TaxCalculator.Test.Core
{
    [TestFixture]
    public class LevierTester
    {
        [Test]
        public void Can_Get_Total_Tax()
        {
            var levier = new Levier {BeforeTaxAmount = 47.50m};
            levier.AddTaxCalculater(new TaxCalculater(0.1, new TaxRounder()));
            levier.AddTaxCalculater(new CommonsTaxCalculater(new TaxRounder()));

            decimal taxAmount = levier.Tax();

            Assert.AreEqual(7.15m, taxAmount);
        }
    }
}