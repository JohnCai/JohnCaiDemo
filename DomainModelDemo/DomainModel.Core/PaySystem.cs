using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mavis.Core;

namespace DomainModel.Core
{
    public class PaySystem: Entity
    {
        public PaySystem()
        {
            AddRule(new SimpleRule("Code", "the Code should not be empty!", () => string.IsNullOrEmpty(Code)));
            AddRule(new SimpleRule("Name", "the Code should not be empty!", () => string.IsNullOrEmpty(Name)));
        }

        public string Code { get; set; }
        public string Name { get; set; }
    }
}
