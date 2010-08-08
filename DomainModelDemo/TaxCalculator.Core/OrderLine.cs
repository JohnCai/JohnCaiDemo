using System;

namespace TaxCalculator.Core
{
    public class OrderLine
    {
        public OrderLine()
        {}

        public OrderLine(ISaleItem saleItem) : this(saleItem, 1)
        {}

        public OrderLine(ISaleItem saleItem, int quantity): this(saleItem, quantity, Product.DefaultUnit)
        {}

        private OrderLine(ISaleItem saleItem, int quantity, Unit unit)
        {
            if (saleItem == null)
                throw new ArgumentNullException("product", "The Product can not be null!");

            Item = saleItem;
            Quantity = quantity;
            ItemUnit = unit;
        }

        public Unit ItemUnit { get; private set; }

        public ISaleItem Item { get; private set; }

        public int Quantity { get; private set; }

        public virtual decimal GetAfterTaxAmount()
        {
            //return Item.GetAfterTaxPrice()*Quantity;
            return GetTotalTax() + GetBeforeTaxAmount();
        }

        public virtual decimal GetTotalTax()
        {
            return Item.GetTax()*Quantity;
        }

        public virtual decimal GetBeforeTaxAmount()
        {
            return Item.Price*Quantity;
        }
    }
}