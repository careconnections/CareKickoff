using System;
using System.ComponentModel.DataAnnotations;
using CareKickoff.Infrastructure.Builders;
using CareKickoff.Infrastructure.Services;
using CareKickoff.Specification.Base;
using CareKickoff.Specification.Helpers;
using NUnit.Framework;

namespace CareKickoff.Specification {
    [TestFixture]
    internal class EmployeeServiceTests : TestFixtureBase {
        [Test]
        public void Ensure_Complete_Employee_Is_Created() {
            var employeeService = DependencyInjector.GetService<EmployeeService>();
            var employee = new EmployeeEntityBuilder()
                .WithName("Michael")
                .ToEntity();

            var beforeCount = employeeService.GetAll().Length;

            employeeService.Create(employee);

            var afterCount = employeeService.GetAll().Length;
            
            Assert.Greater(afterCount, beforeCount);
        }

        [Test]
        public void Ensure_Incomplete_Employee_Is_Rejected() {
            var employeeService = DependencyInjector.GetService<EmployeeService>();
            var employee = new EmployeeEntityBuilder().ToEntity();

            Assert.Throws<ValidationException>(() => {
                employeeService.Create(employee);
            });
        }
        
        [Test]
        public void Ensure_Employee_Is_Deleted() {
            var employeeService = DependencyInjector.GetService<EmployeeService>();
            var employee = employeeService.GetById(1);

            employeeService.Delete(employee);

            Assert.Throws<InvalidOperationException>(() => {
                employeeService.GetById(1);
            });
        }
    }
}