using System;
using System.Threading.Tasks;
using CareKickOff.Services.Interfaces;

namespace CareKickOff.Services
{
    public class BasicAuthenticationService : IBasicAuthenticationService
    {
        public BasicAuthenticationService()
        {
        }

        public bool Login(int username, string password)
        {
            if(username == 1 || username == 2 || username == 3)
            {
                Config.Username = username;
                return true;
            }
            return false;
        }
    }
}
