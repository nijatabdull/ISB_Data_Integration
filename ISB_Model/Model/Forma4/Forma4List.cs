using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ISB_Model.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ISB_Service.Model.ViewModel
{
    [Serializable]
    public class Forma4List
    {
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [JsonProperty("docNumber")]
        public string DocNumber { get; set; }

        [JsonProperty("actionDate")]
        public string ActionDate { get; set; }

        [JsonIgnore]
        public string IncidentStatusId { get; set; }
        [ForeignKey("IncidentStatusId")]
        [JsonProperty("incidentStatus")]
        public IncidentStatus_Forma4 IncidentStatus { get; set; }

        [JsonIgnore]
        public string CompletionStatusId { get; set; }
        [ForeignKey("CompletionStatusId")]
        [JsonProperty("completionStatus")]
        public CompletionStatus_Forma4 CompletionStatus { get; set; }

        [JsonProperty("incidentTypeList")]
        public List<IncidentTypeList_Forma4> IncidentTypeList { get; set; }

        [JsonIgnore]
        public string IncidentRegionId { get; set; }
        [ForeignKey("IncidentRegionId")]
        [JsonProperty("incidentRegion")]
        public IncidentRegion_Forma4 IncidentRegion { get; set; }

        [JsonProperty("vehicleWrapperList")]
        public List<VehicleWrapperList_Forma4> VehicleWrapperList { get; set; }

        [JsonProperty("personWrapperList")]
        public List<PersonWrapperList_Forma4> PersonWrapperList { get; set; }

        [JsonProperty("forma4Attachments")]
        public List<string> Forma4Attachments { get; set; }

        [JsonProperty("actionLocation")]
        public string ActionLocation { get; set; }

        [JsonIgnore]
        public string EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        [JsonProperty("employee")]
        public Employee_Forma4 Employee { get; set; }
    }
}
