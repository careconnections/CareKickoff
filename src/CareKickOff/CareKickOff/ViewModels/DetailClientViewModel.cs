using System;
using CareKickOff.Models;
using CareKickOff.ViewModels.Interfaces;

namespace CareKickOff.ViewModels
{
    public class DetailClientViewModel : ViewModel, IParameterViewModel<Client>
    {
        public Client currentClient;

        public DetailClientViewModel()
        {
            Title = $"Reports";
        }

        public void SetParameter(Client client)
        {
            currentClient = client;
            Title = $"Reports: {currentClient.FirstName} {currentClient.LastName}";
        }
    }
}
