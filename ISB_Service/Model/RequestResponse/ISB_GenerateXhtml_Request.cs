using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB_Service.Model.RequestResponse
{
    class ISB_GenerateXhtml_Request
    {
        [JsonProperty("compId")]
        public string CompId { get; set; }

        [JsonProperty("requestNumber")]
        public string RequestNumber { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("jsonStr")]
        public string JsonStr { get; set; }

        [JsonProperty("appName")]
        public string AppName { get; set; }
    }
}
