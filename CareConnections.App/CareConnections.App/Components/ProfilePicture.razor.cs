using Microsoft.AspNetCore.Components;

namespace CareConnections.App.Components
{
    public partial class ProfilePicture
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }
    }
}
