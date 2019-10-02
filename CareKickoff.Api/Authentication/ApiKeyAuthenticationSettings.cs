using System.Collections.Generic;

namespace CareKickoff.Api.Authentication {
    public class ApiKeyAuthenticationSettings {
        public const string ApiKeyHeaderName = "X-Api-Key";

        public static Dictionary<string, int> ApiKeys = new Dictionary<string, int>() {
            { "DAE89B8D-5E8D-46D2-8449-EB74BA928A4B", 1 },
            { "E1B500C6-69C0-4AFC-9729-03C526827E33", 2 },
            { "56D27A3E-D2EC-41C6-B6A7-301743948CB8", 3 }
        };
    }
}