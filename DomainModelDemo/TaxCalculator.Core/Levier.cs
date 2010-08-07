using System;
using System.Collections.Generic;

namespace TaxCalculator.Core
{
    public class Levier
    {
        public IList<ITaxCalculater> TaxCalculaters { get; private set; }

        public decimal BeforeTaxAmount { get; set; }

        public Levier()
        {
            TaxCalculaters = new List<ITaxCalculater>();
        }

        public void AddTaxCalculater(ITaxCalculater calculater)
        {
            TaxCalculaters.Add(calculater);
        }

        public decimal Tax()
        {
            decimal result = 0;
            foreach (var calculater in TaxCalculaters)
            {
                result += calculater.CalculateTax(BeforeTaxAmount);
            }
            return result;
        }
    }
}