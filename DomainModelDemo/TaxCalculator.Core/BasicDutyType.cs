using System;
using System.Globalization;
using Mavis.Core;

namespace TaxCalculator.Core
{
    public sealed class BasicDutyType: Entity
    {
        public BasicDutyType(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name", "the name can't be null or empty");

            Name = name;

            AddRule(new SimpleRule("TaxRate", "the TaxRate can not be negative!", () => TaxRate < 0));
        }

        public override bool Equals(object obj)
        {
            var another = obj as BasicDutyType;
            if (another == null)
                return false;

            return string.Compare(Name, another.Name, false, CultureInfo.CurrentCulture) == 0;
            //return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int hashCode = GetType().GetHashCode();
            return (hashCode * HASH_MULTIPLIER) ^ Name.GetHashCode();
        }

        public string Name { get; set; }

        public double TaxRate { get; set; }

        private const int HASH_MULTIPLIER = 31;
    }
}