using System.Linq;
using CareKickoff.Infrastructure.Builders;
using CareKickoff.Infrastructure.Services;
using CareKickoff.Specification.Base;
using CareKickoff.Specification.Helpers;
using NUnit.Framework;

namespace CareKickoff.Specification {
    [TestFixture]
    internal class AuthorizationServiceTests : TestFixtureBase {
        [Test]
        public void Ensure_Authorization_Is_Created() {
            var authorizationService = DependencyInjector.GetService<AuthorizationService>();
            
            var authorization = new AuthorizationEntityBuilder()
                .WithEmployeeId(1)
                .WithClientId(3)
                .ToEntity();

            var beforeCount = authorizationService.GetByEmployeeId(1).Length;

            authorizationService.Create(authorization);

            var afterCount = authorizationService.GetByEmployeeId(1).Length;
            
            Assert.Greater(afterCount, beforeCount);
        }

        [Test]
        public void Ensure_Authorization_Is_Deleted() {
            var authorizationService = DependencyInjector.GetService<AuthorizationService>();
            var beforeCount = authorizationService.GetByEmployeeId(1).Length;
            var authorization = authorizationService.GetByEmployeeId(1).First();

            authorizationService.Delete(authorization);

            var afterCount = authorizationService.GetByEmployeeId(1).Length;

            Assert.Less(afterCount, beforeCount);
        }
    }
}