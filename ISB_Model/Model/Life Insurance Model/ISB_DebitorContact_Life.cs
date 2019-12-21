using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISB_Model.Model.Life_Insurance_Model
{
    public class ISB_DebitorContact_Life
    {
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [JsonProperty("contactTypePcode")]
        public string ContactTypePcode { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("fax")]
        public string Fax { get; set; }

        [JsonProperty("gsm1")]
        public string Gsm1 { get; set; }

        [JsonProperty("gsm2")]
        public string Gsm2 { get; set; }

        [JsonProperty("tel1")]
        public string Tel1 { get; set; }

        [JsonProperty("tel2")]
        public string Tel2 { get; set; }

        [JsonProperty("web")]
        public string Web { get; set; }
    }
}