using System;
using System.Collections.Generic;
using Mavis.Core;

namespace TaxCalculator.Core
{
    public class Product: Entity
    {
        public static readonly Unit DefaultUnit = new Unit("default");
        public string Name { get; set; }

        public IList<Unit> Units { get; private set; }

        public Product(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            Name = name;

            Units = new List<Unit> {DefaultUnit};
        }

        public void AddUnit(Unit unit)
        {
            Units.Add(unit);
        }

    }
}