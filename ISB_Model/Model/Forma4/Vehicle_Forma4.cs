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
    public class Vehicle_Forma4
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

        [JsonProperty("certNumber")]
        public string CertNumber { get; set; }

        [JsonProperty("carNumber")]
        public string CarNumber { get; set; }

        [JsonProperty("marka")]
        public string Marka { get; set; }

        [JsonIgnore]
        public string VehicleTypeId { get; set; }
        [ForeignKey("VehicleTypeId")]
        [JsonProperty("vehicleType")]
        public VehicleType_Forma4 VehicleType { get; set; }
    }
}
