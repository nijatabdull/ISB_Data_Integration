using ISB_Infra.Attribute;
using Newtonsoft.Json;
using System;

namespace ISB_Model.Model
{
    [Serializable]
    public class IncidentDetail
    {
        [JsonIgnore]
        public long NOTICE_ID { get; set; }

        [DbPropertyUpdatable]
        [JsonProperty(PropertyName = "oid")]
        public string Oid { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "areaType")]
        public string AreaType { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "hasMutualConsent")]
        public bool? HasMutualConsent { get; set; }

        [JsonProperty(PropertyName = "hasPoliceReport")]
        [DbPropertyChangeType]
        public byte? HasPoliceReport { get; set; }

        [JsonProperty(PropertyName = "hasPoliceQuest")]
        [DbPropertyChangeType]
        public byte? HasPoliceQuest { get; set; }

        [JsonProperty(PropertyName = "incidentDescription")]
        public string IncidentDescription { get; set; }

        [JsonProperty(PropertyName = "incidentLocation")]
        public string IncidentLocation { get; set; }

        [JsonProperty(PropertyName = "incidentType")]
        public string IncidentType { get; set; }

        [JsonProperty(PropertyName = "detailNote")]
        public string DetailNote { get; set; }

        [JsonProperty(PropertyName = "policeOfficer")]
        public string PoliceOfficer { get; set; }

        [JsonProperty(PropertyName = "policeQuestDate")]
        public DateTime? PoliceQuestDate { get; set; }

        [JsonProperty(PropertyName = "policeDepartmentContactType")]
        public string PoliceDepartmentContactType { get; set; }

        [JsonProperty(PropertyName = "policeReportSendDate")]
        public DateTime? PoliceReportSendDate { get; set; }

        [JsonProperty(PropertyName = "policeReportArrivalDate")]
        public DateTime? PoliceReportArrivalDate { get; set; }

        [JsonProperty(PropertyName = "policeTitle")]
        public string PoliceTitle { get; set; }

        [JsonProperty(PropertyName = "policeDepartment")]
        public string PoliceDepartment { get; set; }

        [JsonProperty(PropertyName = "policeDepartmentName")]
        public string PoliceDepartmentName { get; set; }

        [JsonProperty(PropertyName = "policePhone")]
        public string PolicePhone { get; set; }

        [JsonProperty(PropertyName = "policeReportNote")]
        public string PoliceReportNote { get; set; }

        [JsonProperty(PropertyName = "courtDepartment")]
        public string CourtDepartment { get; set; }

        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }

        [JsonProperty(PropertyName = "village")]
        public string Village { get; set; }

        [JsonProperty(PropertyName = "street")]
        public string Street { get; set; }

        [JsonProperty(PropertyName = "highway")]
        public string Highway { get; set; }

        [JsonProperty(PropertyName = "kilometer")]
        public decimal? Kilometer { get; set; }
    }
}
