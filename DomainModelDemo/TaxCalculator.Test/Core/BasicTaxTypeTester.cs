using System;
using NUnit.Framework;
using TaxCalculator.Core;

namespace TaxCalculator.Test.Core
{
    [TestFixture]
    public class BasicTaxTypeTester
    {
        [Test]
        public void Construct_BasicTaxType_Without_Name_Would_Raise_Exception()
        {
            Assert.Throws(typeof(ArgumentNullException), () => new BasicDutyType(string.Empty));
        }

        [Test]
        public void BasicTaxTypes_Should_Be_Equal_With_The_Same_Name()
        {
            var type1 = new BasicDutyType("Book");
            var type2 = new BasicDutyType("Book");
            Assert.AreEqual(type1, type2);
        }

        [Test]
        public void BasicTaxType_With_Negative_TaxRate_Is_Invalid()
        {
            var type = new BasicDutyType("Book") {TaxRate = -0.1};
            Assert.IsFalse(type.IsValid);
        }
    }
}