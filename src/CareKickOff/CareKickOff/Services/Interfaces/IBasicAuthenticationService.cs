using System;
using System.Threading.Tasks;

namespace CareKickOff.Services.Interfaces
{
    public interface IBasicAuthenticationService
    {
        Task<bool> Login(string username);
    }
}
