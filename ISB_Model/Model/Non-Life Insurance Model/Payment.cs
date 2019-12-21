using ISB_Infra.Attribute;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB_Model.Model
{
    [Serializable]
    public class Payment
    {
        [JsonIgnore]
        public long EXECUTIVE_ID { get; set; }

        [JsonProperty(PropertyName = "amountPaid")]
        public string AmountPaid { get; set; }

        [JsonProperty(PropertyName = "dateApproved")]
        public DateTime DateApproved { get; set; }

        [JsonProperty(PropertyName = "datePaid")]
        public DateTime DatePaid { get; set; }

        [JsonProperty(PropertyName = "paymentCode")]
        public string PaymentCode { get; set; }

        [JsonProperty(PropertyName = "paymentStatus")]
        public string PaymentStatus { get; set; }

        [JsonProperty(PropertyName = "paymentType")]
        public string PaymentType { get; set; }

        [JsonProperty(PropertyName = "bankName")]
        public string BankName { get; set; }

        [JsonProperty(PropertyName = "bankTin")]
        public string BankTin { get; set; }

        [JsonProperty(PropertyName = "intAccountNumber")]
        public string IntAccountNumber { get; set; }

        [JsonProperty(PropertyName = "accountNumber")]
        public string AccountNumber { get; set; }

        [JsonProperty(PropertyName = "swift")]
        public string Swift { get; set; }
    
        [JsonProperty(PropertyName = "code")]
        public string Code { get; set; }

        [JsonProperty(PropertyName = "currencyType")]
        public string CurrencyType { get; set; }

        [JsonProperty(PropertyName = "paymentPurpose")]
        public string PaymentPurpose { get; set; }

        [JsonProperty(PropertyName = "additionInfo")]
        public string AdditionInfo { get; set; }

        [JsonProperty(PropertyName = "budgetClassificationCode")]
        public string BudgetClassificationCode { get; set; }

        [JsonProperty(PropertyName = "budgetLevelCode")]
        public string BudgetLevelCode { get; set; }

        [JsonProperty(PropertyName = "beneficiaryOid")]
        [DbPropertyForeignKey]
        public string BeneficiaryOid { get; set; }

        [JsonProperty(PropertyName = "claimDocOid")]
        public string ClaimDocOid { get; set; }

        [JsonProperty(PropertyName = "payer_bank")]
        public string Payer_bank { get; set; }

        [JsonProperty(PropertyName = "payer_bank_code")]
        public string Payer_bank_code { get; set; }

        [JsonProperty(PropertyName = "payer_bank_voen")]
        public string Payer_bank_voen { get; set; }

        [JsonProperty(PropertyName = "payer_correspondent_account")]
        public string Payer_correspondent_account { get; set; }

        [JsonProperty(PropertyName = "payer_swift")]
        public string Payer_swift { get; set; }

        [JsonProperty(PropertyName = "payer_name")]
        public string Payer_name { get; set; }

        [JsonProperty(PropertyName = "payer_account")]
        public string Payer_account { get; set; }

        [JsonProperty(PropertyName = "payer_person_tin")]
        public string Payer_person_tin { get; set; }

        [JsonProperty(PropertyName = "beneficiary_name")]
        public string Beneficiary_name { get; set; }

        [JsonProperty(PropertyName = "beneficiary_voen")]
        public string Beneficiary_voen { get; set; }

        [JsonProperty(PropertyName = "note")]
        public string Note { get; set; }

        [JsonIgnore]
        [DbPropertyUpdatable]
        public bool IsPosted { get; set; }

        [JsonIgnore]
        [DbPropertyUpdatable]
        public string RequestNumber { get; set; }

        [JsonIgnore]
        [DbPropertyUpdatable]
        public string DocumentId { get; set; }

        [JsonIgnore]
        [DbPropertyUpdatable]
        public string DocumentNumber { get; set; }

        [JsonIgnore]
        [DbPropertyUpdatable]
        public string CheckStatusOid { get; set; }
    }
}
