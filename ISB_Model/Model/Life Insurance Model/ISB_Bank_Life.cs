using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB_Model.Model.Life_Insurance_Model
{
    public class ISB_Bank_Life
    {
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [JsonProperty("bankCode")]
        public string BankCode { get; set; }

        [JsonProperty("bankName")]
        public string BankName { get; set; }

        [JsonProperty("corrIban")]
        public string CorrIban { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("swiftNo")]
        public string SwiftNo { get; set; }

        [JsonProperty("taxId")]
        public string TaxId { get; set; }
    }
}
