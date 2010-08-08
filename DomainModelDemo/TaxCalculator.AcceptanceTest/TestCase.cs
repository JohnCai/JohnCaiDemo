using System.Collections.Generic;
using NUnit.Framework;
using TaxCalculator.Core;
using System.Linq;

namespace TaxCalculator.AcceptanceTest
{
    [TestFixture]
    public class TestCase
    {
        protected List<BasicDutyType> _stubBasicDutyTypes;

        protected BasicDutyType FindBasicDutyType(string name)
        {
            return _stubBasicDutyTypes.FirstOrDefault(x => x.Name == name);
        }

        [SetUp]
        public void SetUp()
        {
            _stubBasicDutyTypes = new List<BasicDutyType>
                                      {
                                          new BasicDutyType("Books") {TaxRate = 0},
                                          new BasicDutyType("Food") {TaxRate = 0},
                                          new BasicDutyType("Medicine") {TaxRate = 0},
                                          new BasicDutyType("Others") {TaxRate = 0.1}
                                      };
        }

        [Test]
        public void TestCase1()
        {
            var order = new SalesOrder();

            order.AddOrderLine(CreateOrderLine("书", "Books", 12.49m));
            order.AddOrderLine(CreateOrderLine("CD", "Others", 14.99m));
            order.AddOrderLine(CreateOrderLine("巧克力", "条", "Food", 0.85m, false));

            Assert.AreEqual(12.49m, order.OrderLines[0].GetAfterTaxAmount());
            Assert.AreEqual(16.49m, order.OrderLines[1].GetAfterTaxAmount());
            Assert.AreEqual(0.85m, order.OrderLines[2].GetAfterTaxAmount());

            Assert.AreEqual(1.5m, order.GetTotalTax());
            Assert.AreEqual(29.83m, order.GetTotalAfterTaxAmount());
        }

        [Test]
        public void TestCase2()
        {
            var order = new SalesOrder();

            order.AddOrderLine(CreateOrderLine("巧克力", "盒", "Food", 10.00m, true));
            order.AddOrderLine(CreateOrderLine("香水", "瓶", "Others", 47.50m, true));

            Assert.AreEqual(10.50m, order.OrderLines[0].GetAfterTaxAmount());
            Assert.AreEqual(54.65m, order.OrderLines[1].GetAfterTaxAmount());

            Assert.AreEqual(7.65m, order.GetTotalTax());
            Assert.AreEqual(65.15m, order.GetTotalAfterTaxAmount());
        }

        [Test]
        public void TestCase3()
        {
            var order = new SalesOrder();

            order.AddOrderLine(CreateOrderLine("香水", "瓶", "Others", 27.99m, true));
            order.AddOrderLine(CreateOrderLine("香水", "瓶", "Others", 18.99m ,false));
            order.AddOrderLine(CreateOrderLine("头痛药", "包", "Medicine", 9.75m, false));
            order.AddOrderLine(CreateOrderLine("巧克力", "盒", "Food", 11.25m, true));

            Assert.AreEqual(32.19m, order.OrderLines[0].GetAfterTaxAmount());
            Assert.AreEqual(20.89m, order.OrderLines[1].GetAfterTaxAmount());
            Assert.AreEqual(9.75m, order.OrderLines[2].GetAfterTaxAmount());
            Assert.AreEqual(11.85m, order.OrderLines[3].GetAfterTaxAmount());

            Assert.AreEqual(6.70m, order.GetTotalTax());
            Assert.AreEqual(74.68m, order.GetTotalAfterTaxAmount());
        }

        private OrderLine CreateOrderLine(string productName, string basicDutyTypeName, decimal price)
        {
            return CreateOrderLine(productName, string.Empty, basicDutyTypeName, price, false);
        }

        private OrderLine CreateOrderLine(string productName, string unitName, string basicDutyTypeName, decimal price, bool isImported)
        {
            var saleItem = string.IsNullOrEmpty(unitName)
                               ? new SaleItem(new Product(productName))
                               : new SaleItem(new Product(productName), new Unit(unitName));
            saleItem.IsImported = isImported;
            saleItem.Price = price;
            saleItem.BasicDutyType = FindBasicDutyType(basicDutyTypeName);

            return new OrderLine(saleItem);
        }

        
    }
}