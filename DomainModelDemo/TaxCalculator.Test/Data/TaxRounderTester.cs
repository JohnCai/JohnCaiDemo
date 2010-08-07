using NUnit.Framework;
using TaxCalculator.Core;

namespace TaxCalculator.Test.Data
{
    [TestFixture]
    public class TaxRounderTester
    {
        [Test]
        public void CanRound()
        {
            var taxRounder = new TaxRounder();

            Assert.AreEqual(0.50m, taxRounder.Round(0.499m));
            Assert.AreEqual(3.50m, taxRounder.Round(3.469m));
            Assert.AreEqual(3.45m, taxRounder.Round(3.419m));
            Assert.AreEqual(3.40m, taxRounder.Round(3.40m));
        }
    }
}