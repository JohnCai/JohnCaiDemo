using NUnit.Framework;
using System;
using TaxCalculator.Core;

namespace TaxCalculator.Test.Core
{
    [TestFixture]
    public class UnitTester
    {
        [Test]
        public void  ConstructUnitWithoutName_Would_RaiseException()
        {
            Assert.Throws(typeof (ArgumentNullException), () => new Unit(string.Empty));
        }
    }
}