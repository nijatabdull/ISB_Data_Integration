using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISB_Model.Model.Life_Insurance_Model
{
    public class ISB_InstallmentList_Life
    {
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("installmentDate")]
        public string InstallmentDate { get; set; }

        [JsonProperty("installmentNumber")]
        public string InstallmentNumber { get; set; }

        [JsonIgnore]
        public long? InvoiceId { get; set; }
        [ForeignKey("InvoiceId")]
        [JsonProperty("invoice")]
        public virtual ISB_Invoice_Life Invoice { get; set; }

        [JsonProperty("statusPcode")]
        public string StatusPcode { get; set; }

        [JsonIgnore]
        public long ContractListId { get; set; }
    }
}