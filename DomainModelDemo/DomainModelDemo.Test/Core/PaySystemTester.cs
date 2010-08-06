using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DomainModel.Core;
using Mavis.Framework.Test;

namespace DomainModelDemo.Test.Core
{
    [TestFixture]
    public class PaySystemTester
    {
        private PaySystem _paySystemSut;

        [SetUp]
        public void SetUp()
        {
            _paySystemSut = new PaySystem();
            _paySystemSut.Code.ShouldBeNullOrEmpty();
            _paySystemSut.Name.ShouldBeNullOrEmpty();
        }

        [Test]
        public void PaySystemWithCodeAndNameShouldBeValid()
        {
            _paySystemSut.IsValid.ShouldBeFalse();

            _paySystemSut.Code = "1";
            _paySystemSut.Name = "PaySystem1";

            _paySystemSut.IsValid.ShouldBeTrue();         

        }
    }
}
