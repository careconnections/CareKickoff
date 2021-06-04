using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CareKickoff.Models;
using Newtonsoft.Json;

namespace CareKickoff.Services
{
    public class ClientService
    {

        ClientModel[] clients;
        CareplanModel[] careplans;
        
        public ClientService()
        {
            string pathClients = @"e:\Projects\CareKickoff\Data\clients.json";
            clients = JsonConvert.DeserializeObject<ClientModel[]>(File.ReadAllText(pathClients));

            string pathCareplans = @"e:\Projects\CareKickoff\Data\careplans.json";
            careplans = JsonConvert.DeserializeObject<CareplanModel[]>(File.ReadAllText(pathCareplans));
        }

        public ClientModel GetClientFromId(int id)
        {
            return clients.FirstOrDefault(x => x.NativeId == id);
        }

        public IEnumerable<CareplanModel> GetCareplansFromClient(int id)
        {
            return careplans.Where(x => x.ClientId == id);
        }
    }
}
