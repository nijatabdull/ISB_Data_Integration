using ISB_Infra.Attribute;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ISB_Model.Model
{
    [Serializable]
    public class DamagedPerson
    {
        [JsonIgnore]
        public long NOTICE_ID { get; set; }

        [JsonIgnore]
        public long CUSTOMER_ID { get; set; }

        [DbPropertyUpdatable]
        [JsonProperty(PropertyName = "oid")]
        public string Oid { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "contactType")]
        public string ContactType { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "hasDied")]
        [DbPropertyChangeType]
        public byte? HasDied { get; set; }

        [JsonProperty(PropertyName = "phoneType")]
        public string PhoneType { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "isGuilty")]
        [DbPropertyChangeType]
        public byte? IsGuilty { get; set; }

        [JsonIgnore]
        [DbPropertyUpdatable]
        public string PersonOid { get; set; }
        [JsonProperty(PropertyName = "person")]
        [DbPropertyIgnore]
        public Person Person { get; set; }

        [JsonProperty(PropertyName = "damageList")]
        [DbPropertyIgnore]
        public List<DamageList> DamageList { get; set; }

        [JsonIgnore]
        [DbPropertyUpdatable]
        public string IncidentOid { get; set; }
    }
}
