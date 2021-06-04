using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CareKickoff.Models
{
    public class ViewModel
    {
        public ClientModel Client { get; set; }
        public IEnumerable<CareplanModel> Careplans { get; set; }
    }
}
