using System.Diagnostics;
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
        public void Product_Without_ProductType_Is_Invalid()
        {
            var product = new Product("book") {BasicDutyType = null};
            Assert.IsFalse(product.IsValid);
        }

        [Test]
        public void Product_With_Negative_Price_Is_Invalid()
        {
            var product = new Product("book")
                              {
                                  BasicDutyType = new BasicDutyType("Book"),
                                  Price = -1.55m
                              };
            Assert.IsFalse(product.IsValid);
        }

        [Test]
        public void Product_IsNot_Imported_By_Default()
        {
            var product = new Product("book");
            Assert.IsFalse(product.IsImported);
        }

        [Test]
        public void Can_Get_Correct_Description_For_NonImported_Product()
        {
            var product = new Product("book");
            product.IsImported = false;
            Assert.AreEqual("book", product.GetPrintingDesc());
        }

        [Test] 
        public void Can_Get_Correct_Description_For_Imported_Product()
        {
            var product = new Product("book");
            product.IsImported = true;
            Assert.AreEqual("Imported book", product.GetPrintingDesc());
        }

        [Test]
        public void Should_Have_One_Default_Unit()
        {
            var product = new Product("book a");

            Assert.IsNotNull(product.Units);
            Assert.AreEqual(1, product.Units.Count);
            Assert.AreSame(Product.DefaultUnit, product.Units[0]);
        }
    }
}