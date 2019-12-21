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
    public class VehicleWrapperList_Forma4
    {
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [JsonIgnore]
        public string VehicleId { get; set; }
        [ForeignKey("VehicleId")]
        [JsonProperty("vehicle")]
        public Vehicle_Forma4 Vehicle { get; set; }

        [JsonIgnore]
        public string TechnicalFailureId { get; set; }
        [ForeignKey("TechnicalFailureId")]
        [JsonProperty("technicalFailure")]
        public TechnicalFailure_Forma4 TechnicalFailure { get; set; }

        [JsonIgnore]
        public string Forma4ListId { get; set; }
    }
}
