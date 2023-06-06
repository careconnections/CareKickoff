using CareKickoff.Models;
using CareKickoff.Properties;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace CareKickoff.Data;

public class ClientService : IClientService

{
    public Task<Client[]> GetAllClientsAsync()
	{
        var clients = LoadClientsJson();
		return Task.FromResult(clients.ToArray());
	}

    public Task<Client> GetClientByIdAsync(int id)
    {
        var clients = LoadClientsJson();
        var client = clients.Where(i => i.NativeId == id).FirstOrDefault();

        return Task.FromResult(client);
    }

    public List<Client> LoadClientsJson()
    {
        return JsonConvert.DeserializeObject<List<Client>>(Resources.clients.ToString());
    }
}

