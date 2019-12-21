using System;
using Newtonsoft.Json;

namespace ISB_Service.Model.RequestResponse
{
    class ISB_Login_Request
    {
        [JsonProperty("compId")]
        public string CompId { get; set; }

        [JsonProperty("requestNumber")]
        public string RequestNumber { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("userpassword")]
        public string Userpassword { get; set; }
    }
}
