using ISB_Service.Model.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB_Service.Model.RequestResponse
{
    class ISB_CallService_Response
    {
        [JsonProperty("transactionNumber")]
        public string TransactionNumber { get; set; }

        [JsonProperty("response")]
        public ResponseViewModel Response { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("pagination")]
        public string Pagination { get; set; }

        [JsonProperty("sessionData")]
        public string SessionData { get; set; }

        [JsonProperty("oid")]
        public string Oid { get; set; }

        [JsonProperty("access_token")]
        public string Access_token { get; set; }

        [JsonProperty("refresh_token")]
        public string Refresh_token { get; set; }
    }
}
