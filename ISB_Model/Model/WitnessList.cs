using ISB_Infra.Attribute;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB_Model.Model
{
    [Serializable]
    public class WitnessList
    {
        [JsonProperty("oid")]
        public string Oid { get; set; }

        [JsonProperty("pin")]
        public string Pin { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("serialName")]
        public string SerialName { get; set; }

        [JsonProperty("serialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("fatherName")]
        public string FatherName { get; set; }

        [JsonProperty("birthday")]
        public string Birthday { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("validUntilDate")]
        public string ValidUntilDate { get; set; }

        [JsonProperty("isLegal")]
        [DbPropertyChangeType]
        public byte? IsLegal { get; set; }

        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [JsonProperty("tin")]
        public string Tin { get; set; }

        [JsonProperty("legalType")]
        public string LegalType { get; set; }

        [JsonProperty("legalAddress")]
        public string LegalAddress { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("incidentOid")]
        public string IncidentOid { get; set; }
    }
}
