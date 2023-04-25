using Microsoft.AspNetCore.Components;

namespace CareConnections.App.Pages
{
    public partial class Authentication
    {
        [Parameter]
        public string Action { get; set; } = string.Empty;
    }
}
