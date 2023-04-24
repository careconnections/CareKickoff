using CareConnections.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace CareConnections.App.Components
{
    public partial class ClientCard
    {
        [Parameter]
        public Client Client { get; set; } = default!;

        [Parameter]
        public EventCallback<Client> ClientDetailsClicked { get; set; }
    }
}