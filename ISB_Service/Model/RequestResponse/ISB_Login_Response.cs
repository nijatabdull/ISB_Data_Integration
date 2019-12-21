using ISB_Service.Model.ViewModel;
using Newtonsoft.Json;
using System;

namespace ISB_Service.Model.RequestResponse
{
    class ISB_Login_Response
    {
        [JsonProperty("transactionNumber")]
        public string TransactionNumber { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("level")]
        public string Level { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        public static implicit operator ISB_Login_Response(LoginResponseViewModel loginResponseViewModel)
        {
            return new ISB_Login_Response
            {
                Code = loginResponseViewModel.Response.Code,
                Level = loginResponseViewModel.Response.Level,
                Message = loginResponseViewModel.Response.Message,
                Token = loginResponseViewModel.Token,
                TransactionNumber = loginResponseViewModel.TransactionNumber
            };
        }
    }
}
