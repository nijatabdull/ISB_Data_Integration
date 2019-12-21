using ISB_Infra.Attribute;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ISB_Model.Model
{
    [Serializable]
    public class DamagedPerson
    {
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
        [DbProperyForeignKey]
        public string PersonOid { get; set; }
        [JsonProperty(PropertyName = "person")]
        [DbPropertyIgnore]
        public Person Person { get; set; }

        [JsonProperty(PropertyName = "damageList")]
        [DbPropertyIgnore]
        public List<DamageList> DamageList { get; set; }

        [JsonIgnore]
        [DbProperyForeignKey]
        public string IncidentOid { get; set; }
    }
}
