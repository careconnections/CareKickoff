using System;
using System.Threading.Tasks;
using CareKickOff.Services.Interfaces;

namespace CareKickOff.Services
{
    public class BasicAuthenticationService : IBasicAuthenticationService
    {
        public static string UserName;
        public BasicAuthenticationService()
        {
        }

        public async Task<bool> Login(string username)
        {
            return true;
        }
    }
}
