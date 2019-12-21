using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB_Service.Model.ViewModel
{
    class CallServiceContentViewModel
    {
        [JsonProperty("fileId")]
        public string FileId { get; set; }

        [JsonProperty("applicationName")]
        public string ApplicationName { get; set; }

        [JsonProperty("docOid")]
        public string DocOid { get; set; }

        [JsonProperty("isData")]
        public byte IsData { get; set; }

        [JsonProperty("isMain")]
        public byte IsMain { get; set; }

        [JsonProperty("dataToParse")]
        public string DataToParse { get; set; }

        [JsonProperty("toAccount")]
        public string ToAccount { get; set; }

        [JsonProperty("fileType")]
        public string FileType { get; set; }
    }
}
