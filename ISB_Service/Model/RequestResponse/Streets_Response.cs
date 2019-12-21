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
    class Streets_Response
    {
        [JsonProperty("transactionNumber")]
        public string TransactionNumber { get; set; }

        [JsonProperty("response")]
        public ResponseViewModel Response { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("district")]
        public string District { get; set; }

        [JsonProperty("zipCode")]
        public string ZipCode { get; set; }
    }
}
