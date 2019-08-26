using CareConnection.Core.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace CareConnection.Core
{
    class ClientProvider
    {
        List<Clients> clientList;

        private ClientProvider() => GetClientList();

        private static ClientProvider instance = null;
        public static ClientProvider Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ClientProvider();
                }
                return instance;
            }
        }

        private void GetClientList()
        {
            string clientFileName = "DataFiles.clients.json";
            var assembly = typeof(ClientProvider).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{clientFileName}");
            using (StreamReader r = new StreamReader(stream))
            {
                string json = r.ReadToEnd();
                clientList = JsonConvert.DeserializeObject<List<Clients>>(json);
            }
        }

        #region public methods
        public List<Clients> GetClientsByIds(List<int> employIds)
        {
            List<Clients> clientListById = new List<Clients>();
            foreach (Clients client in clientList)
            {
                if (employIds.Contains(client.NativeID))
                {
                    clientListById.Add(client);
                }
            }
            return clientListById;
        }
        #endregion
    }
}