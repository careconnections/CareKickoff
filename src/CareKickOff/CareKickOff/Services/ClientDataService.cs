using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using CareKickOff.Models;
using CareKickOff.Pages;
using CareKickOff.Services.Interfaces;
using Newtonsoft.Json;

namespace CareKickOff.Services
{
    public class ClientDataService : IClientDataService
    {
        public ObservableCollection<Client> GetClients(int client)
        {
            string jsonEmployeeName = "employees.json";
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            Employee employee;
            var employeeStream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonEmployeeName}");
            using (var reader = new StreamReader(employeeStream))
            {
                string json = reader.ReadToEnd();
                var employees = JsonConvert.DeserializeObject<List<Employee>>(json);
                employee = employees.FirstOrDefault(x => x.EmployeeId == client);
                
            }


            string jsonFileName = "clients.json";
            ObservableCollection<Client> clients = new ObservableCollection<Client>();
            var stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
            using (var reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();
                var items = JsonConvert.DeserializeObject<ObservableCollection<Client>>(json);
                foreach(var authorizedClient in employee.AuthorizedClients)
                {
                    var item = items.FirstOrDefault(x => x.NativeId == authorizedClient);
                    if(item != null)
                    {
                        clients.Add(item);
                    }

                }
                return clients;
            }
            
        }

        public ObservableCollection<Report> GetReportsOfClient(long clientNumber)
        {
            string jsonFileName = "reports.json";
            var assembly = typeof(MainPage).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{jsonFileName}");
            using (var reader = new StreamReader(stream))
            {
                string json = reader.ReadToEnd();
                var items = JsonConvert.DeserializeObject<ObservableCollection<Report>>(json);
                return new ObservableCollection<Report>(items.Where(c => c.ClientId == clientNumber).OrderBy(c => c.CreatedAt));
            }
        }
    }
}
