using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB_Service.Model.ViewModel
{
    class LoginResponseViewModel
    {
        [JsonProperty("transactionNumber")]
        public string TransactionNumber { get; set; }
        
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("response")]
        public ResponseViewModel Response { get; set; }
    }
    
}
