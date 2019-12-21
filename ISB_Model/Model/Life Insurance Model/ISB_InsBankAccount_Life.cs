using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISB_Model.Model.Life_Insurance_Model
{
    public class ISB_InsBankAccount_Life
    {
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long InsBankAccountId { get; set; }

        [JsonProperty("accountNo")]
        public string AccountNo { get; set; }

        [JsonIgnore]
        public long? BankId { get; set; }
        [ForeignKey("BankId")]
        [JsonProperty("bank")]
        public virtual ISB_Bank_Life Bank { get; set; }

        [JsonIgnore]
        public long? BankBranchId { get; set; }
        [ForeignKey("BankBranchId")]
        [JsonProperty("bankBranch")]
        public virtual ISB_BankBranch_Life BankBranch { get; set; }

        [JsonProperty("countryCode")]
        public string CountryCode { get; set; }

        [JsonProperty("countryName")]
        public string CountryName { get; set; }

        [JsonProperty("currencyPcode")]
        public string CurrencyPcode { get; set; }

        [JsonProperty("customerNo")]
        public string CustomerNo { get; set; }

        [JsonProperty("iban")]
        public string Iban { get; set; }

        [JsonProperty("integrationInformation")]
        public string IntegrationInformation { get; set; }
    }
}