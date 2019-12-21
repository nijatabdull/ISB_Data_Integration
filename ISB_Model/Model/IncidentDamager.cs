using ISB_Infra.Attribute;
using Newtonsoft.Json;
using System;

namespace ISB_Model.Model
{
    [Serializable]
    public class IncidentDamager
    {
        [JsonProperty(PropertyName = "oid")]
        public string Oid { get; set; }

        [JsonProperty(PropertyName = "currentAddress")]
        public string CurrentAddress { get; set; }

        [JsonProperty(PropertyName = "hasDriverLicense")]
        public bool? HasDriverLicense { get; set; }

        [JsonProperty(PropertyName = "driverLicenseSn")]
        public string DriverLicenseSn { get; set; }

        [JsonProperty(PropertyName = "driverLicenseNumber")]
        public string DriverLicenseNumber { get; set; }

        [JsonProperty(PropertyName = "driverLicenseIssueDate")]
        public DateTime? DriverLicenseIssueDate { get; set; }

        [JsonProperty(PropertyName = "driverLicenseExpiryDate")]
        public DateTime? DriverLicenseExpiryDate { get; set; }

        [JsonProperty(PropertyName = "hasDied")]
        [DbPropertyChangeType]
        public byte? HasDied { get; set; }

        [JsonProperty(PropertyName = "hasLeftScene")]
        [DbPropertyChangeType]
        public byte? HasLeftScene { get; set; }

        [JsonProperty(PropertyName = "isDrunk")]
        [DbPropertyChangeType]
        public byte? IsDrunk { get; set; }

        [JsonProperty(PropertyName = "isOwner")]
        [DbPropertyChangeType]
        public byte? IsOwner { get; set; }

        [JsonProperty(PropertyName = "isTrustee")]
        [DbPropertyChangeType]
        public byte? IsTrustee { get; set; }

        [JsonProperty(PropertyName = "contactType")]
        public string ContactType { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "deathCertificateNumber")]
        public string DeathCertificateNumber { get; set; }

        [JsonIgnore]
        [DbProperyForeignKey]
        public string PersonOid { get; set; }
        [DbPropertyIgnore]
        [JsonProperty(PropertyName = "person")]
        public Person Person { get; set; }
    }
}
