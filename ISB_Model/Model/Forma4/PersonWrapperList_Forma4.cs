using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB_Service.Model.ViewModel
{
    [Serializable]
    public class PersonWrapperList_Forma4
    {
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [JsonIgnore]
        public string PersonId { get; set; }
        [ForeignKey("PersonId")]
        [JsonProperty("person")]
        public Person_Forma4 Person { get; set; }

        [JsonProperty("foreign")]
        public bool Foreign { get; set; }

        [JsonProperty("diriverLicenseExists")]
        public bool DiriverLicenseExists { get; set; }

        [JsonIgnore]
        public string DriverTypeId { get; set; }
        [ForeignKey("DriverTypeId")]
        [JsonProperty("driverType")]
        public DriverType_Forma4 DriverType { get; set; }

        [JsonIgnore]
        public string DriverStatusId { get; set; }
        [ForeignKey("DriverStatusId")]
        [JsonProperty("driverStatus")]
        public DriverStatus_Forma4 DriverStatus { get; set; }

        [JsonIgnore]
        public string DamageTypeId { get; set; }
        [ForeignKey("DamageTypeId")]
        [JsonProperty("damageType")]
        public DamageType_Forma4 DamageType { get; set; }

        [JsonIgnore]
        public string PersonStatuseId { get; set; }
        [ForeignKey("PersonStatuseId")]
        [JsonProperty("personStatus")]
        public PersonStatus_Forma4 PersonStatus { get; set; }

        [JsonIgnore]
        public string ParticipanTypeId { get; set; }
        [ForeignKey("ParticipanTypeId")]
        [JsonProperty("participanType")]
        public ParticipanType_Forma4 ParticipanType { get; set; }

        [JsonProperty("proSeriesNumber")]
        public string ProSeriesNumber { get; set; }

        [JsonProperty("dlSeriesNumber")]
        public string DlSeriesNumber { get; set; }

        [JsonProperty("vehicleNumber")]
        public string VehicleNumber { get; set; }

        [JsonIgnore]
        public string Forma4ListId { get; set; }
    }
}
