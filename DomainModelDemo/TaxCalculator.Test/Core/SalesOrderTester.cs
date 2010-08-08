using System;
using Moq;
using NUnit.Framework;
using TaxCalculator.Core;

namespace TaxCalculator.Test.Core
{
    [TestFixture]
    public class SalesOrderTester
    {
        [Test]
        public void Can_Add_OrderLine()
        {
            var order = new SalesOrder();

            order.AddOrderLine(new OrderLine(new SaleItem(new Product("a"))));

            Assert.AreEqual(1, order.OrderLines.Count);
        }

        [Test]
        public void Can_Get_Total_Tax()
        {
            var order = new SalesOrder();
            order.AddOrderLine(CreateMockOrderLine(1.55m, 2.55m, 4.10m));
            order.AddOrderLine(CreateMockOrderLine(2.93m, 1.10m, 4.03m));
            
            decimal totalBeforeTax = order.GetTotalBeforeTaxAmount();
            decimal totalTax = order.GetTotalTax();
            decimal totalAfterTax = order.GetTotalAfterTaxAmount();

            Assert.AreEqual(1.55m + 2.93m, totalBeforeTax);
            Assert.AreEqual(2.55m + 1.10m, totalTax);
            Assert.AreEqual(4.10m + 4.03m, totalAfterTax);
        }

        private OrderLine CreateMockOrderLine(decimal beforeTaxAmount, decimal tax, decimal afterTaxAmount)
        {
            var orderLine = new Mock<OrderLine>();
            orderLine.Setup(x => x.GetBeforeTaxAmount()).Returns(beforeTaxAmount);
            orderLine.Setup(x => x.GetTotalTax()).Returns(tax);
            orderLine.Setup(x => x.GetAfterTaxAmount()).Returns(afterTaxAmount);
            return orderLine.Object;
        }
    }
}