using ISB_Service.Model.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB_Service.Model.RequestResponse
{
    class ISB_GenerateXhtml_Response
    {
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("xhtmlBase64")]
        public string XhtmlBase64 { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

        public static implicit operator ISB_GenerateXhtml_Response
            (GenerateXhtmlResponseViewModel generateXhtmlResponseViewModel)
        {
            return new ISB_GenerateXhtml_Response
            {
                Code = generateXhtmlResponseViewModel?.Response?.Code,
                Level = generateXhtmlResponseViewModel?.Response?.Level,
                Message = generateXhtmlResponseViewModel?.Response?.Message,
                Token = generateXhtmlResponseViewModel?.Token,
                XhtmlBase64 = generateXhtmlResponseViewModel?.XhtmlBase64
            };
        }
    }
}
