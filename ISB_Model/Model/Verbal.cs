using Newtonsoft.Json;
using System;
using ISB_Infra;
using ISB_Infra.Attribute;

namespace ISB_Model.Model
{
    [Serializable]
    public class Verbal
    {
        [JsonProperty(PropertyName ="oid")]
        public string Oid { get; set; }

        [JsonProperty(PropertyName = "applicationId")]
        public string ApplicationId { get; set; }

        [JsonProperty(PropertyName = "incidentDate")]
        public DateTime? IncidentDate { get; set; }

        [JsonProperty(PropertyName = "plate")]
        public string Plate { get; set; }

        [JsonProperty(PropertyName = "firstName")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "fatherName")]
        public string FatherName { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "contactType")]
        public string ContactType { get; set; }

        [JsonProperty(PropertyName = "insuranceRisks")]
        public string InsuranceRisks { get; set; }

        [JsonProperty(PropertyName = "incidentAddress")]
        public string IncidentAddress { get; set; }

        [JsonProperty(PropertyName = "insuranceType")]
        public string InsuranceType { get; set; }

        [JsonProperty(PropertyName = "delayReason")]
        public string DelayReason { get; set; }

        [JsonProperty(PropertyName = "note")]
        public string Note { get; set; }

        [JsonProperty(PropertyName = "isInjured")]
        [DbPropertyChangeType]
        public byte? IsInjured { get; set; }

        [JsonProperty(PropertyName = "isDamaged")]
        [DbPropertyChangeType]
        public byte? IsDamaged { get; set; }

        [JsonProperty(PropertyName = "hasConflict")]
        [DbPropertyChangeType]
        public byte? HasConflict { get; set; }

        [JsonProperty(PropertyName = "vehicleMake")]
        public string VehicleMake { get; set; }

        [JsonProperty(PropertyName = "vehicleModel")]
        public string VehicleModel { get; set; }

        [JsonProperty(PropertyName = "vehiclePolicyNo")]
        public string VehiclePolicyNo { get; set; }

        [JsonProperty(PropertyName = "vehicleStatus")]
        public string VehicleStatus { get; set; }

        [JsonProperty(PropertyName = "vehicleAddress")]
        public string VehicleAddress { get; set; }

        [JsonProperty(PropertyName = "street")]
        public string Street { get; set; }

        [JsonProperty(PropertyName = "village")]
        public string Village { get; set; }

        [JsonProperty(PropertyName = "district")]
        public string District { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "vehicle")]
        public string Vehicle { get; set; }

        [JsonIgnore]
        public bool IsPosted { get; set; }

        [JsonIgnore]
        public string RequestNumber { get; set; }

        [JsonIgnore]
        public string DocumentId { get; set; }

        [JsonIgnore]
        public string DocumentNumber { get; set; }
    }
}
