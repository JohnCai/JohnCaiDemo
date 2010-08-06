using System;
using TaxCalculator.Core.DataInterfaces;

namespace TaxCalculator.Data
{
    public class TaxRounder : ITaxRounder
    {
        private const decimal Ratio = 0.05m;

        public decimal Round(decimal tax)
        {
            var roundedDecimal = (tax/Ratio);
            var roundedInt = (int)roundedDecimal;
            if (roundedInt < roundedDecimal)
                roundedInt++;

            return Ratio * roundedInt;
        }
    }
}