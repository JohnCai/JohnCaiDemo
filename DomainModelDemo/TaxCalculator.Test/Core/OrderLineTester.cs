using System;
using System.Collections.Generic;
using NUnit.Framework;
using TaxCalculator.Core;
using Moq;

namespace TaxCalculator.Test.Core
{
    [TestFixture]
    public class OrderLineTester
    {
        private ISaleItem _stubSaleItem;

        [SetUp]
        public void SetUp()
        {
            _stubSaleItem = new SaleItem(new Product("a"));

        }

        [Test]
        public void Product_Can_Not_Be_Null()
        {
            Assert.Throws(typeof(ArgumentNullException), () => new OrderLine(null));
        }

        [Test]
        public void Quantity_Should_Be_One_If_Not_Specified()
        {
            var orderLine = new OrderLine(_stubSaleItem);

            Assert.AreEqual(1, orderLine.Quantity);
        }

        [Test]
        public void Unit_Should_Be_DefaultUnit_If_Not_Specified()
        {
            var orderLine1 = new OrderLine(_stubSaleItem);
            var orderLine2 = new OrderLine(_stubSaleItem, 2);

            Assert.AreSame(_stubSaleItem.Product.Units[0], orderLine1.ItemUnit);
            Assert.AreSame(_stubSaleItem.Product.Units[0], orderLine2.ItemUnit);
        }

        [Ignore]
        [Test]
        public void Unit_Should_Be_One_Of_The_Units_Of_Product()
        {
            var product = new Product("book A");
            product.AddUnit(new Unit("bag"));
        }

        [Test]
        public void Can_Get_TotalTax_Correctly()
        {
            var mockProduct1 = new Mock<ISaleItem>();
            mockProduct1.Setup(x => x.GetTax()).Returns(1.50m);
            var orderLine = new OrderLine(mockProduct1.Object, 10);

            decimal totalTax = orderLine.GetTotalTax();

            Assert.AreEqual(15.0m, totalTax);
        }

        [Test]
        public void Can_Get_BeforeTax_Amount_Correctly()
        {
            var mockProduct1 = new Mock<ISaleItem>();
            mockProduct1.SetupGet(x => x.Price).Returns(11.50m);
            var orderLine = new OrderLine(mockProduct1.Object, 10);

            decimal totalTax = orderLine.GetBeforeTaxAmount();

            Assert.AreEqual(115.0m, totalTax);
        }

        [Test]
        public void Can_Get_AfterTax_Amount_Correctly()
        {
            var mockProduct1 = new Mock<ISaleItem>();
            mockProduct1.Setup(x => x.GetTax()).Returns(12.99m);
            mockProduct1.SetupGet(x => x.Price).Returns(11.50m);
            var orderLine = new OrderLine(mockProduct1.Object, 10);

            decimal totalAmount = orderLine.GetAfterTaxAmount();

            Assert.AreEqual(244.90m, totalAmount);
        }
    }
}