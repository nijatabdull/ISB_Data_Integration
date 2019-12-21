using ISB_Infra.Attribute;
using Newtonsoft.Json;
using System;

namespace ISB_Model.Model
{
    [Serializable]
    public class Beneficiary
    {
        [JsonIgnore]
        public long NOTICE_ID { get; set; }

        [JsonIgnore]
        public long CUSTOMER_ID { get; set; }

        [DbPropertyUpdatable]
        [JsonProperty(PropertyName = "createdDate")]
        public string Oid { get; set; }

        [JsonProperty(PropertyName = "amount")]
        public decimal? Amount { get; set; }

        [JsonProperty(PropertyName = "damageType")]
        public string DamageType { get; set; }

        [JsonProperty(PropertyName = "currentAddress")]
        public string CurrentAddress { get; set; }

        [JsonProperty(PropertyName = "contactType")]
        public string ContactType { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "bfcType")]
        public string BfcType { get; set; }

        [JsonProperty(PropertyName = "paymentSum")]
        public decimal? PaymentSum { get; set; }

        [JsonProperty(PropertyName = "beneficiaryCode")]
        public string BeneficiaryCode { get; set; }

        [JsonIgnore]
        [DbPropertyUpdatable]
        public string ClaimOid { get; set; }

        [JsonIgnore]
        [DbPropertyForeignKey]
        public string PersonOid { get; set; }
        [JsonProperty("person")]
        [DbPropertyIgnore]
        public virtual Person Person { get; set; }
    }
}
