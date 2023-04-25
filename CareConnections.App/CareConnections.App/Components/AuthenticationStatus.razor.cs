using Microsoft.AspNetCore.Components.Web;

namespace CareConnections.App.Components
{
    public partial class AuthenticationStatus
    {
        private async Task BeginSignOut(MouseEventArgs args)
        {
            await SignOutManager.SetSignOutState();
            Navigation.NavigateTo("authentication/logout");
        }
    }
}