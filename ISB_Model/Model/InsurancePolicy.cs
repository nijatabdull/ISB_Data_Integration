using ISB_Infra.Attribute;
using Newtonsoft.Json;
using System;

namespace ISB_Model.Model
{
    [Serializable]
    public class InsurancePolicy
    {
        [JsonProperty(PropertyName = "oid")]
        public string Oid { get; set; }

        [JsonProperty(PropertyName = "bmClass")]
        public string BmClass { get; set; }

        [JsonProperty(PropertyName = "effectiveFromDate")]
        public DateTime? EffectiveFromDate { get; set; }

        [JsonProperty(PropertyName = "effectiveToDate")]
        public DateTime? EffectiveToDate { get; set; }

        [JsonProperty(PropertyName = "fromMigration")]
        public string FromMigration { get; set; }

        [JsonProperty(PropertyName = "serialNumber")]
        public string SerialNumber { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        [JsonIgnore]
        [DbProperyForeignKey]
        public string PersonOid { get; set; }
        [JsonProperty(PropertyName = "person")]
        [DbPropertyIgnore]
        public Person Person { get; set; }

        [JsonIgnore]
        [DbProperyForeignKey]
        public string VehicleOid { get; set; }
        [JsonProperty(PropertyName = "vehicle")]
        [DbPropertyIgnore]
        public Vehicle Vehicle { get; set; }
    }
}
