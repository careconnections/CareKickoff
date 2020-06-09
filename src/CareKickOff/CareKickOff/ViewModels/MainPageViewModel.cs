using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CareKickOff.Models;
using CareKickOff.Services.Interfaces;

namespace CareKickOff.ViewModels
{
    public class MainPageViewModel : ViewModel
    {
        private readonly IClientDataService _clientDataService;
        private string _beginText;

        public MainPageViewModel(IClientDataService clientDataService)
        {
            _clientDataService = clientDataService ?? throw new ArgumentNullException(nameof(clientDataService));
            Title = "Clients";
            BeginText = "Dit is een test text";
            Clients = _clientDataService.GetClients(Config.Username);
        }

        public override Task OnAppearing()
        {
            return base.OnAppearing();
        }

        public string BeginText
        {
            get => _beginText;
            set => SetProperty(ref _beginText, value);
        }

        public ObservableCollection<Client> Clients { get; set; } = new ObservableCollection<Client>();
    }
}
