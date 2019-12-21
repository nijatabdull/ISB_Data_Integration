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
    public class ISB_Employeer_Ancestor_Life
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
        public long? AuthPersonId { get; set; }
        [ForeignKey("AuthPersonId")]
        [JsonProperty("authPerson")]
        public virtual ISB_AuthPerson_Life AuthPerson { get; set; }

        [JsonIgnore]
        public long? ContactId { get; set; }
        [ForeignKey("ContactId")]
        [JsonProperty("contact")]
        public virtual ISB_Contact_Life Contact { get; set; }

        [JsonIgnore]
        public long? DelegatedAuthPersonId { get; set; }
        [ForeignKey("DelegatedAuthPersonId")]
        [JsonProperty("delegatedAuthPerson")]
        public virtual ISB_DelegatedAuthPerson_Life DelegatedAuthPerson { get; set; }

        [JsonIgnore]
        public long? EmployeerId { get; set; }
        [ForeignKey("EmployeerId")]
        [JsonProperty("employer")]
        public virtual ISB_Employeer_Life Employeer { get; set; }

        [JsonIgnore]
        public long? SignerPersonId { get; set; }
        [ForeignKey("SignerPersonId")]
        [JsonProperty("signerPerson")]
        public virtual ISB_SignerPerson_Life SignerPerson { get; set; }

        [JsonIgnore]
        public long? BankAccountId { get; set; }
        [ForeignKey("BankAccountId")]
        [JsonProperty("bankAccount")]
        public virtual ISB_BankAccount_Life BankAccount { get; set; }
    }
}
