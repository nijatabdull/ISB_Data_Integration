using ISB_Infra.Attribute;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ISB_Model.Model
{
    [Serializable]
    public class Incident
    {
        public Incident()
        {
            Witnesses = new Witnesses();
        }

        [JsonProperty(PropertyName = "oid")]
        public string Oid { get; set; }

        [JsonProperty(PropertyName = "incidentStatus")]
        [DbPropertyChangeType]
        public byte? IncidentStatus { get; set; }

        [JsonProperty(PropertyName = "incidentDate")]
        public DateTime? IncidentDate { get; set; }

        [JsonProperty(PropertyName = "insuranceType")]
        public string InsuranceType { get; set; }

        [JsonProperty(PropertyName = "note")]
        public string Note { get; set; }

        [JsonProperty(PropertyName = "plate")]
        public string Plate { get; set; }

        [JsonProperty(PropertyName = "plateUnknown")]
        public string PlateUnknown { get; set; }

        [JsonProperty(PropertyName = "policyNumber")]
        public string PolicyNumber { get; set; }

        [JsonProperty(PropertyName = "contactType")]
        public string ContactType { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "docNo")]
        public string DocNo { get; set; }

        [JsonProperty(PropertyName = "district")]
        public string District { get; set; }

        [JsonProperty(PropertyName = "damagerCount")]
        public int? DamagerCount { get; set; }

        [JsonProperty(PropertyName = "incidentDocOid")]
        public string IncidentDocOid { get; set; }

        [JsonProperty(PropertyName = "incidentOid")]
        public string IncidentOid { get; set; }

        [JsonProperty(PropertyName = "insurancePolicyOid")]
        [DbProperyForeignKey]//json 
        public string InsurancePolicyOid { get; set; }
        [JsonProperty(PropertyName = "insurancePolicy")]
        [DbPropertyIgnore]
        public InsurancePolicy InsurancePolicy { get; set; }

        [JsonIgnore]
        [DbProperyForeignKey]
        public string VehicleOid { get; set; }
        [JsonProperty(PropertyName = "vehicle")]
        [DbPropertyIgnore]
        public Vehicle Vehicle { get; set; }

        [JsonIgnore]
        [DbProperyForeignKey]
        public string PersonOid { get; set; }
        [JsonProperty(PropertyName = "person")]
        [DbPropertyIgnore]
        public Person Person { get; set; }

        [JsonProperty(PropertyName = "witnesses")]
        [DbPropertyIgnore]
        public Witnesses Witnesses { get; set; }

        [JsonIgnore]
        [DbProperyForeignKey]
        public string IncidentDetailOid { get; set; }
        [JsonProperty(PropertyName = "incidentDetail")]
        [DbPropertyIgnore]
        public IncidentDetail IncidentDetail { get; set; }

        [JsonIgnore]
        [DbProperyForeignKey]
        public string IncidentDamagerOid { get; set; }
        [JsonProperty(PropertyName = "incidentDamager")]
        [DbPropertyIgnore]
        public IncidentDamager IncidentDamager { get; set; }

        [JsonProperty(PropertyName = "damagedPersons")]
        [DbPropertyIgnore]
        public List<DamagedPerson> DamagedPersons { get; set; }

        [JsonProperty(PropertyName = "attachments")]
        [DbPropertyIgnore]
        public List<Attachment> Attachments { get; set; }

        [JsonIgnore]
        public bool? IsPosted { get; set; }

        [JsonIgnore]
        public string RequestNumber { get; set; }

        [JsonIgnore]
        public string DocumentId { get; set; }

        [JsonIgnore]
        public string DocumentNumber { get; set; }
    }
}
