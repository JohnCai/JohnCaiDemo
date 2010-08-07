using System.Collections.Generic;

namespace TaxCalculator.Core
{
    public interface IProduct
    {
        BasicDutyType BasicDutyType { get; set; }
        bool IsImported { get; set; }
        decimal Price { get; set; }
        IList<Unit> Units { get; }

        decimal GetAfterTaxPrice();
        decimal GetTax();
    }
}