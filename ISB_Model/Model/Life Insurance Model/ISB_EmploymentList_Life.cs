using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISB_Model.Model.Life_Insurance_Model
{
    public class ISB_EmploymentList_Life
    {
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [JsonProperty("actionTypePcode")]
        public string ActionTypePcode { get; set; }

        [JsonProperty("administrativeFee")]
        public string AdministrativeFee { get; set; }

        [JsonProperty("coverage")]
        public string Coverage { get; set; }

        [JsonProperty("coverageDiff")]
        public string CoverageDiff { get; set; }

        [JsonProperty("currencyPcode")]
        public string CurrencyPcode { get; set; }

        [JsonProperty("earnedPremium")]
        public string EarnedPremium { get; set; }

        [JsonProperty("endDate")]
        public string EndDate { get; set; }

        [JsonProperty("insuranceRate")]
        public string InsuranceRate { get; set; }

        [JsonProperty("jobCategoryPcode")]
        public string JobCategoryPcode { get; set; }

        [JsonProperty("jobPositionId")]
        public string JobPositionId { get; set; }

        [JsonProperty("jobPositionPcode")]
        public string JobPositionPcode { get; set; }

        [JsonProperty("premium")]
        public string Premium { get; set; }

        [JsonProperty("premiumDiff")]
        public string PremiumDiff { get; set; }

        [JsonProperty("returnedPremiumFee")]
        public string ReturnedPremiumFee { get; set; }

        [JsonProperty("riskCategoryPcode")]
        public string RiskCategoryPcode { get; set; }

        [JsonProperty("salary")]
        public string Salary { get; set; }

        [JsonProperty("startDate")]
        public string StartDate { get; set; }

        [JsonProperty("terminationDate")]
        public string TerminationDate { get; set; }

        public long? EmployeeListId { get; set; }
    }
}