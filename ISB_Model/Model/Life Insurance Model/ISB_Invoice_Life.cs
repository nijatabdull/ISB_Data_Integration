using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISB_Model.Model.Life_Insurance_Model
{
    public class ISB_Invoice_Life
    {
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [JsonProperty("address")]
        public string AddendumId { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        [JsonProperty("contractId")]
        public string ContractId { get; set; }

        [JsonProperty("contractIdFull")]
        public string ContractIdFull { get; set; }

        [JsonIgnore]
        public long? CreditorId { get; set; }
        [ForeignKey("CreditorId")]
        [JsonProperty("creditor")]
        public virtual ISB_Creditor_Life Creditor { get; set; }

        [JsonIgnore]
        public long? CreditorAddressId { get; set; }
        [ForeignKey("CreditorAddressId")]
        [JsonProperty("creditorAddress")]
        public virtual ISB_CreditorAddress_Life CreditorAddress { get; set; }

        [JsonIgnore]
        public long? CreditorContactId { get; set; }
        [ForeignKey("CreditorContactId")]
        [JsonProperty("creditorContact")]
        public virtual ISB_CreditorContact_Life CreditorContact { get; set; }

        [JsonProperty("currencyCode")]
        public string CurrencyCode { get; set; }

        [JsonIgnore]
        public long? DebitorId { get; set; }
        [ForeignKey("DebitorId")]
        [JsonProperty("debitor")]
        public virtual ISB_Debitor_Life Debitor { get; set; }

        [JsonIgnore]
        public long? DebitorAddressId { get; set; }
        [ForeignKey("DebitorAddressId")]
        [JsonProperty("debitorAddress")]
        public virtual ISB_DebitorAddress_Life DebitorAddress { get; set; }

        [JsonIgnore]
        public long? DebitorContactId { get; set; }
        [ForeignKey("DebitorContactId")]
        [JsonProperty("debitorContact")]
        public virtual ISB_DebitorContact_Life DebitorContact { get; set; }

        [JsonProperty("insCompanyCode")]
        public string InsCompanyCode { get; set; }

        [JsonProperty("installmentDate")]
        public string InstallmentDate { get; set; }

        [JsonProperty("installmentNumber")]
        public string InstallmentNumber { get; set; }

        [JsonProperty("invoiceDate")]
        public string InvoiceDate { get; set; }

        [JsonProperty("invoiceId")]
        public string InvoiceId { get; set; }

        [JsonProperty("invoiceType")]
        public string InvoiceType { get; set; }

        [JsonProperty("paymentList")]
        public virtual List<ISB_PaymentList_Life> PaymentList { get; set; }

        [JsonProperty("paymentReceiverSubCode")]
        public string PaymentReceiverSubCode { get; set; }

        [JsonProperty("renewalId")]
        public string RenewalId { get; set; }

        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }
    }
}