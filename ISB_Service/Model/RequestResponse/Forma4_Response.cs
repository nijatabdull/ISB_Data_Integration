using ISB_Service.Model.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB_Service.Model.RequestResponse
{
    [Serializable]
    class Forma4_Response
    {
        [JsonProperty("transactionNumber")]
        public string TransactionNumber { get; set; }

        [JsonProperty("response")]
        public ResponseViewModel Response { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("forma4List")]
        public List<Forma4List> Forma4List { get; set; }
    }
}
