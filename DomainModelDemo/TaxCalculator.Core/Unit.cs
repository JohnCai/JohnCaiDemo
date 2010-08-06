using System;

namespace TaxCalculator.Core
{
    public class Unit
    {
        public Unit(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
            Name = name;
        }

        protected string Name { get; set; }
    }
}