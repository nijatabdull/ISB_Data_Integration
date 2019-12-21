using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISB_Model.Model.Life_Insurance_Model
{
    public class ISB_BankBranch_Life
    {
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [JsonProperty("bankCode")]
        public string BankCode { get; set; }

        [JsonProperty("bankName")]
        public string BankName { get; set; }

        [JsonProperty("branchCode")]
        public string BranchCode { get; set; }

        [JsonProperty("branchName")]
        public string BranchName { get; set; }

        [JsonProperty("informerAccountCode")]
        public string InformerAccountCode { get; set; }

        [JsonProperty("swiftNo")]
        public string SwiftNo { get; set; }

        [JsonProperty("taxId")]
        public string TaxId { get; set; }
    }
}