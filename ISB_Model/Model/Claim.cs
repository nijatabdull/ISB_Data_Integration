using ISB_Infra.Attribute;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ISB_Model.Model
{
    [Serializable]
    public class Claim
    {
        [JsonProperty(PropertyName = "claimOid")]
        public string ClaimOid { get; set; }

        [JsonProperty(PropertyName = "applicationDate")]
        public DateTime? ApplicationDate { get; set; }

        [JsonProperty(PropertyName = "applicantType")]
        public string ApplicantType { get; set; }

        [JsonProperty(PropertyName = "phone")]
        public string Phone { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "contactType")]
        public string ContactType { get; set; }

        [JsonProperty(PropertyName = "currentAddress")]
        public string CurrentAddress { get; set; }

        [JsonProperty(PropertyName = "incidentDocOid")]
        public string IncidentDocOid { get; set; }

        [DbProperyForeignKey]
        [JsonProperty(PropertyName = "incidentOid")]
        public string IncidentOid { get; set; }

        [JsonProperty(PropertyName = "isApproved")]
        [DbPropertyChangeType]
        public byte? IsApproved { get; set; }

        [JsonIgnore]
        public string PersonOid { get; set; }
        [JsonProperty("person")]
        [DbPropertyIgnore]
        public virtual Person Person { get; set; }

        [JsonIgnore]
        [DbProperyForeignKey]
        public string DamagedPersonOid { get; set; }
        [JsonProperty("damagedPerson")]
        [DbPropertyIgnore]
        public virtual DamagedPerson DamagedPerson { get; set; }

        [JsonProperty(PropertyName = "beneficiaries")]
        [DbPropertyIgnore]
        public List<Beneficiary> Beneficiary { get; set; }

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
