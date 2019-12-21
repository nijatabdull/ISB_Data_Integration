using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ISB_Model.Model.Life_Insurance_Model
{
    public class ISB_Debitor_Life
    {
        [JsonIgnore]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [JsonProperty("dateOfBirth")]
        public string DateOfBirth { get; set; }

        [JsonProperty("dateOfDeath")]
        public string DateOfDeath { get; set; }

        [JsonProperty("economicActivityPcode")]
        public string EconomicActivityPcode { get; set; }

        [JsonProperty("educationStatusPcode")]
        public string EducationStatusPcode { get; set; }

        [JsonProperty("fatherName")]
        public string FatherName { get; set; }

        [JsonProperty("genderPcode")]
        public string GenderPcode { get; set; }

        [JsonProperty("idn")]
        public string Idn { get; set; }

        [JsonProperty("maritalStatusPcode")]
        public string MaritalStatusPcode { get; set; }

        [JsonProperty("middleName")]
        public string MiddleName { get; set; }

        [JsonProperty("motherName")]
        public string MotherName { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nationalityPcode")]
        public string NationalityPcode { get; set; }

        [JsonProperty("passport")]
        public string Passport { get; set; }

        [JsonProperty("personTypePcode")]
        public string PersonTypePcode { get; set; }

        [JsonProperty("placeOfBirth")]
        public string PlaceOfBirth { get; set; }

        [JsonProperty("position")]
        public string Position { get; set; }

        [JsonProperty("surname")]
        public string Surname { get; set; }

        [JsonProperty("taxId")]
        public string TaxId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }
    }
}