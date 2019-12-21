using ISB_Service.Model.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ISB_Service.Model.RequestResponse
{
    class ISB_CheckStatus_Response
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

        [JsonProperty("documentId")]
        public string DocumentId { get; set; }

        [JsonProperty("documentNumber")]
        public string DocumentNumber { get; set; }

        [JsonProperty("errors")]
        public string[] Errors { get; set; }

        [JsonProperty("oid")]
        public string Oid { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        public static implicit operator ISB_CheckStatus_Response(CheckStatusResponseViewModel checkStatusResponse)
        {
            dynamic content = checkStatusResponse?.Info?.Content;

            string documentId = null; string documentNumber = null;

            if (content!=null&&content!=string.Empty)
            {
                dynamic dynamic = JsonConvert.DeserializeObject<dynamic>(content);

                documentId = dynamic.DocumentId;
                documentNumber = dynamic.DocumentNumber;
            }

            return new ISB_CheckStatus_Response()
            {
                TransactionNumber = checkStatusResponse?.TransactionNumber,
                Code = checkStatusResponse?.Response?.Code,
                Message = checkStatusResponse?.Response?.Message,
                Level = checkStatusResponse?.Response?.Level,
                DocumentId = documentId,
                DocumentNumber = documentNumber,
                Token = checkStatusResponse?.Token,
                Errors = checkStatusResponse?.Info?.Errors,
                Oid = checkStatusResponse?.Info?.Oid,
                Status = checkStatusResponse?.Info?.Status
            };
        }
    }
}
