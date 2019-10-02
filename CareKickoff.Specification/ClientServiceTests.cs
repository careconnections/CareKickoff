using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CareKickoff.Domain.Enums;
using CareKickoff.Infrastructure.Builders;
using CareKickoff.Infrastructure.Services;
using CareKickoff.Specification.Base;
using CareKickoff.Specification.Helpers;
using NUnit.Framework;

namespace CareKickoff.Specification {
    [TestFixture]
    internal class ClientServiceTests : TestFixtureBase {
        [Test]
        public void Ensure_Complete_Client_Is_Created() {
            var clientService = DependencyInjector.GetService<ClientService>();
            
            var client = new ClientEntityBuilder()
                .WithFirstName("Michael")
                .WithLastName("Overhorst")
                .WithBirthDate(new DateTime(1989, 11, 17))
                .WithGender(GenderType.Male)
                .ToEntity();
            
            var beforeCount = clientService.GetAll().Length;

            clientService.Create(client);

            var afterCount = clientService.GetAll().Length;
            
            Assert.Greater(afterCount, beforeCount);
        }

        [Test]
        public void Ensure_Incomplete_Client_Is_Rejected() {
            var clientService = DependencyInjector.GetService<ClientService>();
            var client = new ClientEntityBuilder().ToEntity();

            Assert.Throws<ValidationException>(() => {
                clientService.Create(client);
            });
        }

        [Test]
        public void Ensure_Client_Has_Careplan() {
            var clientService = DependencyInjector.GetService<ClientService>();
            var client = clientService.GetById(1);
            
            Assert.NotNull(client.Careplans.FirstOrDefault());
        }
        
        [Test]
        public void Ensure_Client_Is_Deleted() {
            var clientService = DependencyInjector.GetService<ClientService>();
            var client = clientService.GetById(1);

            clientService.Delete(client);

            Assert.Throws<InvalidOperationException>(() => {
                clientService.GetById(1);
            });
        }
    }
}