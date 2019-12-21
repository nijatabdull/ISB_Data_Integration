using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB_Service.Model.ViewModel
{
    [Serializable]
    public class CheckStatusResponseViewModel
    {
        public CheckStatusResponseViewModel()
        {
            Response = new ResponseViewModel();
            Info = new CheckStatus_InfoViewModel();
        }

        [JsonProperty("transactionNumber")]
        public string TransactionNumber { get; set; }

        [JsonProperty("response")]
        public ResponseViewModel Response { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("info")]
        public CheckStatus_InfoViewModel Info { get; set; }
    }
}
