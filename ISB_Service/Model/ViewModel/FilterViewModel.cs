using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB_Service.Model.ViewModel
{
    class FilterViewModel
    {
        [JsonProperty("addendumNumber")]
        public string AddendumNumber { get; set; }

        [JsonProperty("contractNumber")]
        public string ContractNumber { get; set; }

        [JsonProperty("contractType")]
        public string ContractType { get; set; }

        [JsonProperty("employeeIdn")]
        public string EmployeeIdn { get; set; }

        [JsonProperty("employerIdn")]
        public string EmployerIdn { get; set; }

        [JsonProperty("employerTaxId")]
        public string EmployerTaxId { get; set; }

        [JsonProperty("endDate")]
        public string EndDate { get; set; }

        [JsonProperty("insCompanyCode")]
        public string InsCompanyCode { get; set; }

        [JsonProperty("renewalNumber")]
        public string RenewalNumber { get; set; }

        [JsonProperty("startDate")]
        public string StartDate { get; set; }
    }
}
