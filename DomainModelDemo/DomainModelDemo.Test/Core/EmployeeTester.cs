using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using DomainModel.Core;
using Mavis.Framework.Test;

namespace DomainModelDemo.Test
{
    [TestFixture]
    public class EmployeeTester
    {
        private Employee _employeeSut;

        [SetUp]
        public void SetUp()
        {
            _employeeSut = new Employee();
        }

        [Test]
        public void EmployeeWithoutNameIsInvalid()
        {
            _employeeSut.Name = "";

            Assert.IsFalse(_employeeSut.IsValid);
        }

        [Test]
        public void EmployeeWithoutCodeIsInvalid()
        {
            _employeeSut.Code = "";

            Assert.IsFalse(_employeeSut.IsValid);
        }

        [Test]
        public void EmployeeWithCodeAndNameShouldBeValid()
        {
            _employeeSut.Code = "1001";
            _employeeSut.Name = "Jack";

            _employeeSut.IsValid.ShouldBeTrue();
        }

        [Test]
        public void EmployeeShouldBeSalariedByDefault()
        {
            _employeeSut.EmployeeType.ShouldEqual(EmployeeType.Salaried);
        }

        [Test]
        public void CanChangeTypeToHourly()
        {
            _employeeSut.EmployeeType = EmployeeType.Hourly;
            _employeeSut.EmployeeType.ShouldEqual(EmployeeType.Hourly);
        }

        [Test]
        public void PaySystemIsNullByDefault()
        {
            _employeeSut.PaySystem.ShouldBeNull();
        }
    }
}
