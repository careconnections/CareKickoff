using CareKickoff.Properties;
using Newtonsoft.Json;

namespace CareKickoff.Data;

public class CareplanService
{
    public Task<Careplan[]> GetCarePlansForClientAsync(int clientId)
    {
        var careplans = LoadCareplansJson();
        var careplansforclient = careplans.Where(i => i.ClientId == clientId).ToArray();
        return Task.FromResult(careplansforclient);
    }

    private List<Careplan> LoadCareplansJson()
    {
        return JsonConvert.DeserializeObject<List<Careplan>>(Resources.careplans.ToString()); ;
    }
}

