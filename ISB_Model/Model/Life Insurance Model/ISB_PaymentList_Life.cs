using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISB_Model.Model.Life_Insurance_Model
{
    public class ISB_PaymentList_Life
    {
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonProperty("insCompanyCode")]
        public string InsCompanyCode { get; set; }

        [JsonProperty("invoiceId")]
        public string InvoiceId { get; set; }

        [JsonProperty("paymentDate")]
        public string PaymentDate { get; set; }

        [JsonProperty("paymentReceiverSubCode")]
        public string PaymentReceiverSubCode { get; set; }

        [JsonProperty("receiptNumber")]
        public string ReceiptNumber { get; set; }
    }
}