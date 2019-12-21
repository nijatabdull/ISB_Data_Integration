using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISB_Service.Model.ViewModel
{
    [Serializable]
    public class Person_Forma4
    {
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("patronymic")]
        public string Patronymic { get; set; }

        [JsonProperty("birthDate")]
        public string BirthDate { get; set; }

        [JsonProperty("mobileNumber")]
        public string MobileNumber { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonIgnore]
        public string PersonTypeId { get; set; }
        [ForeignKey("PersonTypeId")]
        [JsonProperty("personType")]
        public PersonType_Forma4 PersonType { get; set; }

        [JsonProperty("idNumber")]
        public string IdNumber { get; set; }

        [JsonProperty("pin")]
        public string Pin { get; set; }

        [JsonProperty("taxNumber")]
        public string TaxNumber { get; set; }

        [JsonProperty("passportNo")]
        public string PassportNo { get; set; }

        [JsonProperty("regAddress")]
        public string RegAddress { get; set; }
    }
}
