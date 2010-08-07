using System;
using System.Collections.Generic;
using Mavis.Core;

namespace TaxCalculator.Core
{
    public class Product: Entity
    {
        public static readonly Unit DefaultUnit = new Unit("default");
        public string Name { get; set; }

        public BasicDutyType BasicDutyType { get; set; }

        public bool IsImported { get; set; }

        public decimal Price { get; set; }

        public IList<Unit> Units { get; private set; }

        public Product(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            Name = name;

            Units = new List<Unit> {DefaultUnit};

            AddSimpleBusinessRule();
        }

        private void AddSimpleBusinessRule()
        {
            AddRule(new SimpleRule("BasicDutyType", "The BasicDutyType should not be null!", () => BasicDutyType == null));
            AddRule(new SimpleRule("Price", "The Price should not be negative!", () => Price < 0));
        }

        public string GetPrintingDesc()
        {
            if (IsImported)
                return string.Format("Imported {0}", Name);
            return Name;
        }

        public void AddUnit(Unit unit)
        {
            Units.Add(unit);
        }
    }
}