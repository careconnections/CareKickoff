using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CareKickoff.Api.Authentication {
    public class ApiKeyAuthenticationHandler : AuthenticationHandler<ApiKeyAuthenticationOptions> {
        public ApiKeyAuthenticationHandler(IOptionsMonitor<ApiKeyAuthenticationOptions> options, ILoggerFactory logger,
            UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock) { }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync() {
            if (!Request.Headers.TryGetValue(ApiKeyAuthenticationSettings.ApiKeyHeaderName,
                out var apiKeyHeaderValues)) {
                return AuthenticateResult.NoResult();
            }

            var providedApiKey = apiKeyHeaderValues.FirstOrDefault();

            if (apiKeyHeaderValues.Count == 0 || string.IsNullOrWhiteSpace(providedApiKey)) {
                return AuthenticateResult.NoResult();
            }

            if (ApiKeyAuthenticationSettings.ApiKeys.ContainsKey(providedApiKey)) {
                var apiKey = ApiKeyAuthenticationSettings.ApiKeys[providedApiKey];

                var claims = new List<Claim> {
                    new Claim(ClaimTypes.Name, apiKey.ToString())
                };

                var identity = new ClaimsIdentity(claims, ApiKeyAuthenticationOptions.AuthenticationType);
                var identities = new List<ClaimsIdentity> {identity};
                var principal = new ClaimsPrincipal(identities);
                var ticket = new AuthenticationTicket(principal, ApiKeyAuthenticationOptions.Scheme);

                return AuthenticateResult.Success(ticket);
            }

            return AuthenticateResult.Fail("Invalid API Key provided.");
        }
    }
}