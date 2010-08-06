using System;
using Moq;
using NUnit.Framework;
using TaxCalculator.Core;
using TaxCalculator.Core.DataInterfaces;

namespace TaxCalculator.Test.Core
{
    [TestFixture]
    public class TaxCalculatorTester
    {
        [Test]
        public void AfterTaxPrice_Should_Equal_To_PreTaxPrice_When_TaxRate_Is_Zero()
        {
            const decimal preTaxPrice = 12.49m;

            var taxRounder = new Mock<ITaxRounder>();
            var calc = new TaxCalculater(0, taxRounder.Object);

            decimal price = calc.CalculateTax(preTaxPrice) + preTaxPrice;

            Assert.AreEqual(preTaxPrice, price);
        }

        [Test]
        public void AfterTaxPrice_Should_Be_Calculated_Correctly()
        {
            const decimal preTaxPrice = 14.99m;
            const decimal roundedTax = 1.50m;
            const decimal taxRate = 0.1m;

            var taxRounder = new Mock<ITaxRounder>();
            taxRounder.Setup(x => x.Round(preTaxPrice * taxRate)).Returns(roundedTax);
            var calc = new TaxCalculater((double) taxRate, taxRounder.Object);

            decimal price = calc.CalculateTax(preTaxPrice) + preTaxPrice;

            const decimal expected = preTaxPrice + roundedTax;
            Assert.AreEqual(expected, price);
        }
    }
}