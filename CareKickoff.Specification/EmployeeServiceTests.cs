using System;
using System.ComponentModel.DataAnnotations;
using CareKickoff.Infrastructure.Builders;
using NUnit.Framework;

namespace CareKickoff.Specification {
    [TestFixture]
    internal class EmployeeServiceTests : TestFixtureBase {
        [Test]
        public void Ensure_Complete_Employee_Is_Created() {
            var employee = new EmployeeEntityBuilder()
                .WithName("Michael")
                .ToEntity();

            var beforeCount = EmployeeService.GetAll().Length;

            EmployeeService.Create(employee);

            var afterCount = EmployeeService.GetAll().Length;
            
            Assert.Greater(afterCount, beforeCount);
        }

        [Test]
        public void Ensure_Incomplete_Employee_Is_Rejected() {
            var employee = new EmployeeEntityBuilder().ToEntity();

            Assert.Throws<ValidationException>(() => {
                EmployeeService.Create(employee);
            });
        }
        
        [Test]
        public void Ensure_Employee_Is_Deleted() {
            var employee = EmployeeService.GetById(1);

            EmployeeService.Delete(employee);

            Assert.Throws<InvalidOperationException>(() => {
                EmployeeService.GetById(1);
            });
        }
    }
}