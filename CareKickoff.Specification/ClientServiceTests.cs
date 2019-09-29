using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using CareKickoff.Domain.Enums;
using CareKickoff.Infrastructure.Builders;
using NUnit.Framework;

namespace CareKickoff.Specification {
    [TestFixture]
    internal class ClientServiceTests : TestFixtureBase {
        [Test]
        public void Ensure_Complete_Client_Is_Created() {
            var client = new ClientEntityBuilder()
                .WithFirstName("Michael")
                .WithLastName("Overhorst")
                .WithBirthDate(new DateTime(1989, 11, 17))
                .WithGender(GenderType.Male)
                .ToEntity();
            
            var beforeCount = ClientService.GetAll().Length;

            ClientService.Create(client);

            var afterCount = ClientService.GetAll().Length;
            
            Assert.Greater(afterCount, beforeCount);
        }

        [Test]
        public void Ensure_Incomplete_Client_Is_Rejected() {
            var client = new ClientEntityBuilder().ToEntity();

            Assert.Throws<ValidationException>(() => {
                ClientService.Create(client);
            });
        }

        [Test]
        public void Ensure_Client_Has_Careplan() {
            var client = ClientService.GetById(1);
            
            Assert.NotNull(client.Careplans.FirstOrDefault());
        }
        
        [Test]
        public void Ensure_Client_Is_Deleted() {
            var client = ClientService.GetById(1);

            ClientService.Delete(client);

            Assert.Throws<InvalidOperationException>(() => {
                ClientService.GetById(1);
            });
        }
    }
}