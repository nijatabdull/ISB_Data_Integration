using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISB_Model.Model.Life_Insurance_Model
{
    public class ISB_CreditorAddress_Life
    {
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [JsonProperty("addressDetail")]
        public string AddressDetail { get; set; }

        [JsonProperty("buildingNumber")]
        public string BuildingNumber { get; set; }

        [JsonProperty("cityCode")]
        public string CityCode { get; set; }

        [JsonProperty("cityName")]
        public string CityName { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("countryName")]
        public string CountryName { get; set; }

        [JsonProperty("floorNumber")]
        public string FloorNumber { get; set; }

        [JsonProperty("latitude")]
        public string Latitude { get; set; }

        [JsonProperty("longitude")]
        public string Longitude { get; set; }

        [JsonProperty("postIndex")]
        public string PostIndex { get; set; }

        [JsonProperty("settlement")]
        public string Settlement { get; set; }

        [JsonProperty("stateCode")]
        public string StateCode { get; set; }

        [JsonProperty("stateName")]
        public string StateName { get; set; }

        [JsonProperty("street")]
        public string Street { get; set; }

        [JsonProperty("townCode")]
        public string TownCode { get; set; }

        [JsonProperty("townName")]
        public string TownName { get; set; }
    }
}