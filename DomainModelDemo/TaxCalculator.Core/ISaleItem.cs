using System.Collections.Generic;

namespace TaxCalculator.Core
{
    public interface ISaleItem
    {
        BasicDutyType BasicDutyType { get; set; }
        bool IsImported { get; set; }
        decimal Price { get; set; }
        Unit Unit { get; }

        Product Product { get; }

        decimal GetAfterTaxPrice();
        decimal GetTax();
    }
}