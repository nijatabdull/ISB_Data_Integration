using ISB_Infra.Attribute;
using Newtonsoft.Json;
using System;

namespace ISB_Model.Model
{
    [Serializable]
    public class Attachment
    {
        [JsonIgnore]
        public long NOTICE_ID { get; set; }

        [JsonIgnore]
        public string AttachmentOid { get; set; }

        [JsonProperty(PropertyName = "createdDate")]
        public DateTime? CreatedDate { get; set; }

        [JsonProperty(PropertyName = "fileId")]
        public string FileId { get; set; }

        [JsonProperty(PropertyName = "fileName")]
        public string FileName { get; set; }

        [JsonProperty(PropertyName = "attachmentType")]
        public string AttachmentType { get; set; }

        [JsonProperty(PropertyName = "attachmentTypeName")]
        public string AttachmentTypeName { get; set; }

        [JsonProperty(PropertyName = "attachmentDetail")]
        public string AttachmentDetail { get; set; }

        [JsonIgnore]
        [DbPropertyUpdatable]
        public string IncidentOid { get; set; }

        [JsonIgnore]
        [DbPropertyUpdatable]
        public string ClaimOid { get; set; }
    }
}