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

        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;

        public void NavigateToReports(Client selectedClient) =>
            NavigationManager.NavigateTo($"/reportoverview/{selectedClient.ClientId}");
    }
}