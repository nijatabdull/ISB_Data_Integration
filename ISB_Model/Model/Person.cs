using ISB_Infra.Attribute;
using Newtonsoft.Json;
using System;

namespace ISB_Model.Model
{
    [Serializable]
    public class Person
    {
        [JsonProperty(PropertyName = "oid")]
        public string Oid { get; set; }

        [JsonProperty(PropertyName = "pin")]
        public string Pin { get; set; }

        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }

        [JsonProperty(PropertyName = "serialName")]
        public string SerialName { get; set; }

        [JsonProperty(PropertyName = "serialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "fatherName")]
        public string FatherName { get; set; }

        [JsonProperty(PropertyName = "birthday")]
        public DateTime? Birthday { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "validUntilDate")]
        public DateTime? ValidUntilDate { get; set; }

        [JsonProperty(PropertyName = "isLegal")]
        [DbPropertyChangeType]
        public byte? IsLegal { get; set; }

        [JsonProperty(PropertyName = "companyName")]
        public string CompanyName { get; set; }

        [JsonProperty(PropertyName = "tin")]
        public string Tin { get; set; }

        [JsonProperty(PropertyName = "legalType")]
        public string LegalType { get; set; }

        [JsonProperty(PropertyName = "legalAddress")]
        public string LegalAddress { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
    }
}
