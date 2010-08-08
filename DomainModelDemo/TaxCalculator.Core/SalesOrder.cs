using System.Collections.Generic;

namespace TaxCalculator.Core
{
    public class SalesOrder
    {
        public SalesOrder()
        {
            OrderLines = new List<OrderLine>();
        }

        public void AddOrderLine(OrderLine orderLine)
        {
            OrderLines.Add(orderLine);
        }

        public IList<OrderLine> OrderLines { get; private set; }

        public decimal GetTotalTax()
        {
            decimal result = 0m;
            foreach (var orderLine in OrderLines)
            {
                result += orderLine.GetTotalTax();
            }
            return result;
        }

        public decimal GetTotalBeforeTaxAmount()
        {
            decimal result = 0m;
            foreach (var orderLine in OrderLines)
            {
                result += orderLine.GetBeforeTaxAmount();
            }
            return result;
        }

        public decimal GetTotalAfterTaxAmount()
        {
            decimal result = 0m;
            foreach (var orderLine in OrderLines)
            {
                result += orderLine.GetAfterTaxAmount();
            }
            return result;
        }
    }
}