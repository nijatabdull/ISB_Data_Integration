using ISB_Service.Model.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB_Service.Model.RequestResponse
{
    class ClipContractInfo_Response
    {
        [JsonProperty("transactionNumber")]
        public string TransactionNumber { get; set; }

        [JsonProperty("response")]
        public ResponseViewModel Response { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("contracts")]
        public List<ContractViewModel> Contracts { get; set; }
    }
}
