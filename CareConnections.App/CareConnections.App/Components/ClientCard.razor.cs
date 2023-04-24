using CareConnections.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace CareConnections.App.Components
{
    public partial class ClientCard
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; } = default!;
        
        [Parameter]
        public Client Client { get; set; } = default!;

        [Parameter]
        public EventCallback<Client> ClientDetailsClicked { get; set; }

        public void NavigateToReports(Client selectedClient) =>
            NavigationManager.NavigateTo($"/reportoverview/{selectedClient.ClientId}");
    }
}