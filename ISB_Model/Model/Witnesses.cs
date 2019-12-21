using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB_Model.Model
{
    [Serializable]
    public class Witnesses
    {
        [JsonProperty(PropertyName = "witnessList")]
        public IEnumerable<WitnessList> WitnessList { get; set; } 
    }
}
