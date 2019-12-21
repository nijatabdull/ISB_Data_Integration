using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB_Service.Model.ViewModel
{
    class ContractViewModel
    {
        [JsonProperty("addendumId")]
        public string AddendumId { get; set; }

        [JsonProperty("contractId")]
        public string ContractId { get; set; }

        [JsonProperty("contractIdFull")]
        public string ContractIdFull { get; set; }

        [JsonProperty("statusPcode")]
        public string StatusPcode { get; set; }
    }
}
