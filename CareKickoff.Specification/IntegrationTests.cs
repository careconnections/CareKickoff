using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CareKickoff.Api.Authentication;
using CareKickoff.Specification.Helpers;
using NUnit.Framework;

//     Depends on:
//     Microsoft.AspNetCore.App
//     Microsoft.AspNetCore.Mvc.Testing
namespace CareKickoff.Specification {
    [TestFixture]
    public class IntegrationTests {
        private readonly ApiWebApplicationFactory _factory;
        
        public IntegrationTests() {
            _factory = new ApiWebApplicationFactory();
        }

        [Test]
        [TestCase("/api/client")]
        public async Task Ensure_Employee_Has_Access_To_Endpoints(string url) {
            using (var client = _factory.CreateClient()) {
                AuthorizeHttpClient(client);

                var response = await client.GetAsync(url);
                    
                response.EnsureSuccessStatusCode();
            }
        }

        [Test]
        [TestCase("/api/client")]
        [TestCase("/api/careplan")]
        public async Task Ensure_Unauthorized_User_Has_No_Access(string url) {
            using (var client = _factory.CreateClient()) {
                var response = await client.GetAsync(url);
                    
                Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
            }
        }

        private static void AuthorizeHttpClient(HttpClient httpClient) {
            // Use first Api key (Sander)
            httpClient.DefaultRequestHeaders.Add(
                ApiKeyAuthenticationSettings.ApiKeyHeaderName,
                ApiKeyAuthenticationSettings.ApiKeys.First().Key
            );
        }
        
        [OneTimeTearDown]
        public void TearDown() {
            _factory.Dispose();
        }
    }
}