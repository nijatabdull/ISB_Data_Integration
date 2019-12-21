using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB_Service.Model.ViewModel
{
    [Serializable]
    public class ContentViewModel
    {
        [JsonProperty("DocumentId")]
        public string DocumentId { get; set; }

        [JsonProperty("DocumentNumber")]
        public string DocumentNumber { get; set; }
    }
}
