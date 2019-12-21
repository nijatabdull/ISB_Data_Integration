using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISB_Model.Model.Life_Insurance_Model
{
    public class ISB_EmployeeList_Life
    {
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [JsonIgnore]
        public long? AddressId { get; set; }
        [ForeignKey("AddressId")]
        [JsonProperty("address")]
        public virtual ISB_Address_Life Address { get; set; }

        [JsonIgnore]
        public long? ContactId { get; set; }
        [ForeignKey("ContactId")]
        [JsonProperty("contact")]
        public virtual ISB_Contact_Life Contact { get; set; }

        [JsonProperty("employmentList")]
        public virtual List<ISB_EmploymentList_Life> EmploymentList { get; set; }

        [JsonIgnore]
        public long? PersonId { get; set; }
        [ForeignKey("PersonId")]
        [JsonProperty("person")]
        public virtual ISB_Person_Life Person { get; set; }

        [JsonIgnore]
        public long? ContractListId { get; set; }
    }
}