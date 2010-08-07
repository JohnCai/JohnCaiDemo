using System;
using System.Collections.Generic;
using NUnit.Framework;
using TaxCalculator.Core;

namespace TaxCalculator.Test.Core
{
    [TestFixture]
    public class OrderLineTester
    {
        private Product _stubProduct;

        [SetUp]
        public void SetUp()
        {
            _stubProduct = new Product("book A");

        }

        [Test]
        public void Product_Can_Not_Be_Null()
        {
            Assert.Throws(typeof(ArgumentNullException), () => new OrderLine(null));
        }

        [Test]
        public void Quantity_Should_Be_One_If_Not_Specified()
        {
            var orderLine = new OrderLine(_stubProduct);

            Assert.AreEqual(1, orderLine.Quantity);
        }

        [Test]
        public void Unit_Should_Be_DefaultUnit_If_Not_Specified()
        {
            var orderLine1 = new OrderLine(_stubProduct);
            var orderLine2 = new OrderLine(_stubProduct, 2);

            Assert.AreSame(_stubProduct.Units[0], orderLine1.ItemUnit);
            Assert.AreSame(_stubProduct.Units[0], orderLine2.ItemUnit);
        }

        [Ignore]
        [Test]
        public void Unit_Should_Be_One_Of_The_Units_Of_Product()
        {
            var product = new Product("book A");
            product.AddUnit(new Unit("bag"));
        }

        [Test]
        public void Can_Get_AfterTax_Amount_Correctly()
        {
            //_stubProduct
            var orderLine = new OrderLine(_stubProduct);

        }
    }

    public class OrderLine
    {
        public OrderLine(Product product) : this(product, 1)
        {}

        public OrderLine(Product product, int quantity): this(product, quantity, Product.DefaultUnit)
        {}

        private OrderLine(Product product, int quantity, Unit unit)
        {
            if (product == null)
                throw new ArgumentNullException("product", "The Product can not be null!");

            Item = product;
            Quantity = quantity;
            ItemUnit = unit;
        }

        public Unit ItemUnit { get; private set; }

        public Product Item { get; private set; }

        public int Quantity { get; private set; }
    }
}