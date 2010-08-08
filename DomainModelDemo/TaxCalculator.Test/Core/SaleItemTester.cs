using System;
using Moq;
using NUnit.Framework;
using TaxCalculator.Core;

namespace TaxCalculator.Test.Core
{
    [TestFixture]
    public class SaleItemTester
    {
        private Product _stubProduct;

        [SetUp]
        public void SetUp()
        {
            _stubProduct = new Product("book");
        }

        [Test]
        public void Product_IsNot_Imported_By_Default()
        {
            var saleItem = new SaleItem(_stubProduct);
            Assert.IsFalse(saleItem.IsImported);
        }

        [Test]
        public void Can_Get_Correct_Description_For_NonImported_Product()
        {
            var saleItem = new SaleItem(_stubProduct);
            saleItem.IsImported = false;
            Assert.AreEqual("book", saleItem.GetPrintingDesc());
        }

        [Test]
        public void Can_Get_Correct_Description_For_Imported_Product()
        {
            var saleItem = new SaleItem(_stubProduct);
            saleItem.IsImported = true;
            Assert.AreEqual("Imported book", saleItem.GetPrintingDesc());
        }

        [Test]
        public void Product_With_Negative_Price_Is_Invalid()
        {
            var saleItem = new SaleItem(new Product("book"))
                               {
                                   BasicDutyType = new BasicDutyType("Book"),
                                   Price = -1.55m
                               };
            Assert.IsFalse(saleItem.IsValid);
        }

        [Test]
        public void Product_Without_ProductType_Is_Invalid()
        {
            var saleItem = new SaleItem(new Product("book")) { BasicDutyType = null };
            Assert.IsFalse(saleItem.IsValid);
        }

        [Test]
        public void Can_Get_AfterTaxPrice()
        {
            var service = new Mock<ITaxPriceService>();
            var product = new SaleItem(new Product("a")) { TaxPriceService = service.Object };
            service.Setup(x => x.CalculateAfterTaxPrice(product)).Returns(10.99m);

            var price = product.GetAfterTaxPrice();

            Assert.AreEqual(10.99m, price);
        }

        [Test]
        public void Can_Get_Tax()
        {
            var service = new Mock<ITaxPriceService>();
            var product = new SaleItem(new Product("a")) { TaxPriceService = service.Object };
            service.Setup(x => x.CalculateTax(product)).Returns(1.90m);

            var price = product.GetTax();

            Assert.AreEqual(1.90m, price);
        }
    }
}