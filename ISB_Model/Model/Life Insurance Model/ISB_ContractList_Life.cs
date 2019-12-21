
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
    public class ISB_ContractList_Life
    {
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ContractListId { get; set; }

        [JsonProperty("actionTypePcode")]
        public string ActionTypePcode { get; set; }

        [JsonProperty("addendumEndDate")]
        public string AddendumEndDate { get; set; }

        [JsonProperty("addendumId")]
        public string AddendumId { get; set; }

        [JsonProperty("addendumStartDate")]
        public string AddendumStartDate { get; set; }

        [JsonProperty("addendumTypePcode")]
        public string AddendumTypePcode { get; set; }

        [JsonProperty("administrativeFee")]
        public string AdministrativeFee { get; set; }

        [JsonProperty("contractId")]
        public string ContractId { get; set; }

        [JsonProperty("contractIdFull")]
        public string ContractIdFull { get; set; }

        [JsonProperty("coverage")]
        public string Coverage { get; set; }

        [JsonProperty("coverageDiff")]
        public string CoverageDiff { get; set; }

        [JsonProperty("currencyPcode")]
        public string CurrencyPcode { get; set; }

        [JsonProperty("earnedPremium")]
        public string EarnedPremium { get; set; }

        [JsonProperty("employeeList")]
        public List<ISB_EmployeeList_Life> EmployeeList { get; set; }

        [JsonIgnore]
        public long? EmployeerId { get; set; }
        [JsonProperty("employer")]
        [ForeignKey("EmployeerId")]
        public virtual ISB_Employeer_Ancestor_Life Employeer { get; set; }

        [JsonProperty("endDate")]
        public string EndDate { get; set; }

        [JsonIgnore]
        public long? InsBankAccountId { get; set; }
        [ForeignKey("InsBankAccountId")]
        [JsonProperty("insBankAccount")]
        public virtual ISB_InsBankAccount_Life InsBankAccount { get; set; }

        [JsonProperty("insCompanyCode")]
        public string InsCompanyCode { get; set; }

        [JsonProperty("issueDate")]
        public string IssueDate { get; set; }

        [JsonProperty("lastNotificationDate")]
        public string LastNotificationDate { get; set; }

        [JsonProperty("numberOfInstallments")]
        public string NumberOfInstallments { get; set; }

        [JsonProperty("originalContractId")]
        public string OriginalContractId { get; set; }

        [JsonProperty("premium")]
        public string Premium { get; set; }

        [JsonProperty("premiumDiff")]
        public string PremiumDiff { get; set; }

        [JsonProperty("rejectReasonDesc")]
        public string RejectReasonDesc { get; set; }

        [JsonProperty("rejectReasonPcode")]
        public string RejectReasonPcode { get; set; }

        [JsonProperty("returnedPremiumFee")]
        public string ReturnedPremiumFee { get; set; }

        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [JsonProperty("statusPcode")]
        public string StatusPcode { get; set; }

        [JsonProperty("termReasonOther")]
        public string TermReasonOther { get; set; }

        [JsonProperty("termReasonPcode")]
        public string TermReasonPcode { get; set; }

        [JsonProperty("terminationDate")]
        public string TerminationDate { get; set; }

        [JsonProperty("typePcode")]
        public string TypePcode { get; set; }

        [JsonProperty("uuid")]
        public string Uuid { get; set; }

        [JsonProperty("installmentList")]
        public List<ISB_InstallmentList_Life> InstallmentList { get; set; }

        [JsonProperty("renewalId")]
        public string RenewalId { get; set; }
    }
}
