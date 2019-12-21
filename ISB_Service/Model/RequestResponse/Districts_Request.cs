using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB_Service.Model.RequestResponse
{
    [Serializable]
    class Districts_Request
    {
        [JsonProperty("compId")]
        public string CompId { get; set; }

        [JsonProperty("requestNumber")]
        public string RequestNumber { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
