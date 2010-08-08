using System;
using System.Linq;
using Moq;
using NUnit.Framework;
using TaxCalculator.Core;

namespace TaxCalculator.Test.Core
{
    [TestFixture]
    public class LevierFactoryTester
    {
        [Test]
        public void Can_Generate_Levier_For_NonImported_Product()
        {
            var saleItem = new SaleItem(new Product("a"))
                              {
                                  BasicDutyType = new BasicDutyType("Books"){TaxRate = 0.1},
                                  IsImported = false
                              };
            var levier = new LevierFactory().GenerateLevier(saleItem);
            
            Assert.AreEqual(1, levier.TaxCalculaters.Count);
        }

        [Test]
        public void Can_Generate_Levier_For_Imported_Product()
        {
            var saleItem = new SaleItem(new Product("a"))
                               {
                                   BasicDutyType = new BasicDutyType("Books") {TaxRate = 0.1},
                                   IsImported = true
                               };
            var levier = new LevierFactory().GenerateLevier(saleItem);

            Assert.AreEqual(2, levier.TaxCalculaters.Count);
        }

        [Test]
        public void Can_Generate_Levier_For_Product_Without_BasicDutyType()
        {
            var saleItem = new SaleItem(new Product("a"))
                               {
                                   BasicDutyType = null,
                                   IsImported = false
                               };
            var levier = new LevierFactory().GenerateLevier(saleItem);

            Assert.AreEqual(0, levier.TaxCalculaters.Count);
        }

        [Test]
        public void Can_Generate_Levier_With_BeforeTaxPrice()
        {
            var saleItem = new SaleItem(new Product("a"))
                               {
                                   Price = 19.99m,
                               };
            var levier = new LevierFactory().GenerateLevier(saleItem);

            Assert.AreEqual(19.99m, levier.BeforeTaxAmount);
        }
    }
}