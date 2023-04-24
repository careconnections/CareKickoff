using CareConnections.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace CareConnections.App.Components
{
    public partial class ClientDetailsPopup
    {
        private Client? _client;

        [Parameter]
        public Client? Client { get; set; }

        protected override void OnParametersSet() => 
            _client = Client;

        public void Close() => 
            _client = null;
    }
}
