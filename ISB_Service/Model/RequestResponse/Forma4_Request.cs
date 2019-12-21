using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB_Service.Model.RequestResponse
{
    [Serializable]
    class Forma4_Request
    {
        [JsonProperty("compId")]
        public string CompId { get; set; }

        [JsonProperty("requestNumber")]
        public string RequestNumber { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("carNumber")]
        public string CarNumber { get; set; }

        [JsonProperty("incidentDate")]
        public string IncidentDate { get; set; }
    }
}
