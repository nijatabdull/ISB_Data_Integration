using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB_Service.Model.ViewModel
{
    class GenerateXhtmlResponseViewModel
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("xhtmlBase64")]
        public string XhtmlBase64 { get; set; }

        [JsonProperty("response")]
        public ResponseViewModel Response { get; set; }
    }
}
