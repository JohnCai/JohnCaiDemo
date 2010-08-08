using Moq;
using NUnit.Framework;
using System;
using TaxCalculator.Core;

namespace TaxCalculator.Test.Core
{
    [TestFixture]
    public class ProductTester
    {
        [Test]   
        public void ProductMustHaveName()
        {
            Assert.Throws(typeof (ArgumentNullException), () => new Product(string.Empty));
        }

        
        [Test]
        public void Should_Have_One_Default_Unit()
        {
            var product = new Product("book a");

            Assert.IsNotNull(product.Units);
            Assert.AreEqual(1, product.Units.Count);
            Assert.AreSame(Product.DefaultUnit, product.Units[0]);
        }

        [Test]
        public void Can_Add_Unit()
        {
            var product = new Product("book a");

            var unit = new Unit("bag");
            product.AddUnit(unit);

            Assert.AreEqual(2, product.Units.Count);
            Assert.AreSame(unit, product.Units[1]);
        }

    }
}