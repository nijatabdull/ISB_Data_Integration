using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB_Model.Model
{
    [Serializable]
    public class Vehicle
    {
        [JsonProperty(PropertyName = "vehicleOid")]
        public string VehicleOid { get; set; }

        [JsonProperty(PropertyName = "plate")]
        public string Plate { get; set; }

        [JsonProperty(PropertyName = "color")]
        public string Color { get; set; }

        [JsonProperty(PropertyName = "make")]
        public string Make { get; set; }

        [JsonProperty(PropertyName = "model")]
        public string Model { get; set; }

        [JsonProperty(PropertyName = "vin")]
        public string Vin { get; set; }

        [JsonProperty(PropertyName = "chassis")]
        public string Chassis { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "year")]
        public DateTime? Year { get; set; }

        [JsonProperty(PropertyName = "engineNumber")]
        public string EngineNumber { get; set; }

        [JsonProperty(PropertyName = "engineCapacity")]
        public decimal? EngineCapacity { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "maxMass")]
        public decimal? MaxMass { get; set; }

        [JsonProperty(PropertyName = "seatNumber")]
        public string SeatNumber { get; set; }

        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "regSerialNumber")]
        public string RegSerialNumber { get; set; }
    }
}
