using ISB_Infra.Attribute;
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
        public Witnesses()
        {
            WitnessList = new List<WitnessList>();
        }

        [JsonIgnore]
        public long NOTICE_ID { get; set; }

        [JsonProperty(PropertyName = "witnessList")]
        public List<WitnessList> WitnessList { get; set; } 
    }
}
