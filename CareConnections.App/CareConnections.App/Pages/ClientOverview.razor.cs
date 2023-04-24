using CareConnections.App.Models;
using CareConnections.Shared.Domain;

namespace CareConnections.App.Pages
{
    public partial class ClientOverview
    {
        public IList<Client>? Clients { get; set; } = default!;

        private Client? _selectedClient;

        private readonly string Title = "Client Overview";

        protected override void OnInitialized() => 
            Clients = MockDataService.Clients;

        public void ShowClientDetailsPopup(Client selectedClient) =>
            _selectedClient = selectedClient;
    }
}