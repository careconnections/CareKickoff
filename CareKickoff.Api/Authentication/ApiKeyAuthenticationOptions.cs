using Microsoft.AspNetCore.Authentication;

namespace CareKickoff.Api.Authentication {
    public class ApiKeyAuthenticationOptions : AuthenticationSchemeOptions {
        public const string DefaultScheme = "API Key";
        public static string Scheme => DefaultScheme;
        public static string AuthenticationType => DefaultScheme;
    }
}