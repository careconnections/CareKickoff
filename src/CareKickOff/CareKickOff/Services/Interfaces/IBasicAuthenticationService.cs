using System;
using System.Threading.Tasks;

namespace CareKickOff.Services.Interfaces
{
    public interface IBasicAuthenticationService
    {
        bool Login(int username, string password);
    }
}
