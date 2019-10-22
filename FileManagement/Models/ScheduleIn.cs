using System;
using System.Collections.Generic;
using FileManagement.Infrastructure;
using Newtonsoft.Json;

namespace FileManagement.Models
{
    public class ScheduleIn
    {
        [JsonProperty("result")]
        public IEnumerable<ScheduleInItem> ScheduleInItems { get; set; }
    }

    public class ScheduleInItem
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("master_cost_code")]
        public string MasterCostCode { get; set; }

        [JsonProperty("master_activity_code")]
        public string MasterActivityCode { get; set; }

        [JsonProperty("task_id")]
        public string TaskId { get; set; }

        [JsonProperty("task_name")]
        public string TaskName { get; set; }

        [JsonProperty("planned_start_date")]
        public long PlannedStartDate { get; set; }

        [JsonProperty("planned_end_date")]
        public long PlannedDateEnd { get; set; }

        [JsonProperty("activity_id")]
        public string ActivityId { get; set; }

        [JsonProperty("associated_resources")]
        public IEnumerable<ScheduleItemResource> Resources { get; set; }

        [JsonProperty("sl_no")]
        public int SLNo { get; set; }

        [JsonProperty("sap_id")]
        public string SapId { get; set; }
    }

    public class ScheduleItemResource
    {
        [JsonProperty("consumption_resource_quantity")]
        public int ConsumptionResourceQuantity { get; set; }

        [JsonProperty("consumption_resource_cost")]
        public int ConsumptionResourceCost { get; set; }

        [JsonProperty("resource_code")]
        public  string ResourceCode { get; set; }

        [JsonProperty("resource_name")]
        public string ResourceName { get; set; }

        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }

        [JsonProperty("allocated_resource_quantity")]
        public int AllocatedResourceQuantity { get; set; }

        [JsonProperty("uom")]
        public string UnitOfMeasure { get; set; }
    }
}
