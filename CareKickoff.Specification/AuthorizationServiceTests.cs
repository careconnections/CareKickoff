using System.Linq;
using CareKickoff.Infrastructure.Builders;
using NUnit.Framework;

namespace CareKickoff.Specification {
    [TestFixture]
    internal class AuthorizationServiceTests : TestFixtureBase {
        [Test]
        public void Ensure_Authorization_Is_Created() {
            var authorization = new AuthorizationEntityBuilder()
                .WithEmployeeId(1)
                .WithClientId(3)
                .ToEntity();

            var beforeCount = AuthorizationService.GetByEmployeeId(1).Length;

            AuthorizationService.Create(authorization);

            var afterCount = AuthorizationService.GetByEmployeeId(1).Length;
            
            Assert.Greater(afterCount, beforeCount);
        }

        [Test]
        public void Ensure_Authorization_Is_Deleted() {
            var beforeCount = AuthorizationService.GetByEmployeeId(1).Length;
            var authorization = AuthorizationService.GetByEmployeeId(1).First();

            AuthorizationService.Delete(authorization);

            var afterCount = AuthorizationService.GetByEmployeeId(1).Length;

            Assert.Less(afterCount, beforeCount);
        }
    }
}