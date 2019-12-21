using ISB_Infra.Attribute;
using Newtonsoft.Json;
using System;

namespace ISB_Model.Model
{
    [Serializable]
    public class DamageList
    {
        [JsonProperty(PropertyName = "oid")]
        public string Oid { get; set; }

        [JsonProperty(PropertyName = "damageOid")]
        public string DamageOid { get; set; }

        [JsonProperty(PropertyName = "amountDemanded")]
        public decimal? AmountDemanded { get; set; }

        [JsonProperty(PropertyName = "amountEvaluated")]
        public decimal? AmountEvaluated { get; set; }

        [JsonProperty(PropertyName = "amountEvalStatus")]
        [DbPropertyChangeType]
        public byte? AmountEvalStatus { get; set; }

        [JsonProperty(PropertyName = "damageCode")]
        public string DamageCode { get; set; }

        [JsonProperty(PropertyName = "damageDescription")]
        public string DamageDescription { get; set; }

        [JsonProperty(PropertyName = "damageType")]
        public string DamageType { get; set; }

        [JsonProperty(PropertyName = "disabilityLevel")]
        public string DisabilityLevel { get; set; }

        [JsonProperty(PropertyName = "injuryType")]
        public string InjuryType { get; set; }

        [JsonProperty(PropertyName = "plate")]
        public string Plate { get; set; }

        [JsonProperty(PropertyName = "propertyType")]
        public string PropertyType { get; set; }

        [JsonProperty(PropertyName = "propertyDocType")]
        public string PropertyDocType { get; set; }

        [JsonProperty(PropertyName = "propertyDocNumber")]
        public string PropertyDocNumber { get; set; }

        [JsonProperty(PropertyName = "damageCost")]
        public decimal? DamageCost { get; set; }

        [JsonIgnore]
        [DbProperyForeignKey]
        public virtual string VehicleOid { get; set; }
        [JsonProperty(PropertyName = "vehicle")]
        [DbPropertyIgnore]
        public virtual Vehicle Vehicle { get; set; }

        [JsonIgnore]
        [DbProperyForeignKey]
        public string DamagedPersonOid { get; set; }
    }
}
