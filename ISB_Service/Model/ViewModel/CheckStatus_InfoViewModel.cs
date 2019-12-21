using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB_Service.Model.ViewModel
{
    [Serializable]
    public class CheckStatus_InfoViewModel
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("errors")]
        public string[] Errors { get; set; }

        [JsonProperty("oid")]
        public string Oid { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
