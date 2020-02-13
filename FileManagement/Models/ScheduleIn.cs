using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace FileManagement.Models
{
    public class ScheduleIn
    {
        [Required(ErrorMessage = "Result is required")]
        [JsonProperty("result")]
        public ScheduleInResult Result { get; set; }
    }

    public class ScheduleInResult
    {
        [Required(ErrorMessage = "Project Id is required")]
        [JsonProperty("project_id")]
        public string ProjectId { get; set; }

        [Required(ErrorMessage = "Project Name is required")]
        [JsonProperty("project_name")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Task is required")]
        [JsonProperty("task")]
        public IEnumerable<ScheduleInItem> ScheduleInItems { get; set; }
    }

    public class ScheduleInItem
    {
        [Required(ErrorMessage = "Status is required")]
        [JsonProperty("status")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Master Cost Code is required")]
        [JsonProperty("master_cost_code")]
        public string MasterCostCode { get; set; }

        [Required(ErrorMessage = "Master Activity Code is required")]
        [JsonProperty("master_activity_code")]
        public string MasterActivityCode { get; set; }

        [Required(ErrorMessage = "Task Id is required")]
        [JsonProperty("task_id")]
        public string TaskId { get; set; }

        [Required(ErrorMessage = "Task Name is required")]
        [JsonProperty("task_name")]
        public string TaskName { get; set; }

        [Required(ErrorMessage = "Planned Start Date is required")]
        [JsonProperty("planned_start_date")]
        public long PlannedStartDate { get; set; }

        [Required(ErrorMessage = "Planed End Date is required")]
        [JsonProperty("planned_end_date")]
        public long PlannedDateEnd { get; set; }

        [Required(ErrorMessage = "Activity Id is required")]
        [JsonProperty("activity_id")]
        public string ActivityId { get; set; }

        [Required(ErrorMessage = "Associated Resource is required")]
        [JsonProperty("associated_resources")]
        public IEnumerable<ScheduleItemResource> Resources { get; set; }

        [Required(ErrorMessage = "SL No is required")]
        [JsonProperty("sl_no")]
        public int SLNo { get; set; }

        [Required(ErrorMessage = "SAP Id is required")]
        [JsonProperty("sap_id")]
        public string SapId { get; set; }
    }

    public class ScheduleItemResource
    {
        [Required(ErrorMessage = "Consumption Resource Quantity is required")]
        [JsonProperty("consumption_resource_quantity")]
        public int ConsumptionResourceQuantity { get; set; }

        [Required(ErrorMessage = "Consumption Resource Cost is required")]
        [JsonProperty("consumption_resource_cost")]
        public int ConsumptionResourceCost { get; set; }

        [Required(ErrorMessage = "Resource Code is required")]
        [JsonProperty("resource_code")]
        public  string ResourceCode { get; set; }

        [Required(ErrorMessage = "Resource Name is required")]
        [JsonProperty("resource_name")]
        public string ResourceName { get; set; }

        [Required(ErrorMessage = "Resource Type is required")]
        [JsonProperty("resource_type")]
        public string ResourceType { get; set; }

        [Required(ErrorMessage = "Allocated Resource Quantity is required")]
        [JsonProperty("allocated_resource_quantity")]
        public int AllocatedResourceQuantity { get; set; }

        [Required(ErrorMessage = "Unit Of Measure is required")]
        [JsonProperty("uom")]
        public string UnitOfMeasure { get; set; }
    }
}
