using CareConnections.App.Services;
using CareConnections.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace CareConnections.App.Pages
{
    public partial class ClientOverview
    {
        [Inject]
        public IClientDataService ClientDataService { get; set; } = default!;
        
        public IList<Client>? Clients { get; set; } = default!;

        private Client? _selectedClient;

        private readonly string Title = "Client Overview";

        protected override async Task OnInitializedAsync() => 
            Clients = await ClientDataService.GetAllClientsAsync();

        public void ShowClientDetailsPopup(Client selectedClient) =>
            _selectedClient = selectedClient;
    }
}