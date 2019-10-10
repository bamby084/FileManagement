using Newtonsoft.Json;

namespace FileManagement.Models
{
    public class ScheduleOut
    {
        [JsonProperty("sap_id")]
        public string SapId { get; set; }

        [JsonProperty("activity_id")]
        public string ActivityId { get; set; }

        [JsonProperty("resource_code")]
        public string ResourceCode { get; set; }

        [JsonProperty("resource_quantity")]
        public double ResourceQuantity { get; set; }
    }
}
