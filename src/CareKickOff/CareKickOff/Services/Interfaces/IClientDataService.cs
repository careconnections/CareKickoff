using System;
using System.Collections.ObjectModel;
using CareKickOff.Models;

namespace CareKickOff.Services.Interfaces
{
    public interface IClientDataService
    {
        ObservableCollection<Client> GetClients(int client);
        ObservableCollection<Report> GetReportsOfClient(long clientNumber);
    }
}
