using FileManagement.Infrastructure;
using FileManagement.Models;
using FileManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace FileManagement.Controllers
{
    [Route("api/schedule-out")]
    public class ScheduleJsonOutController: ApiController
    {
        private readonly IScheduleOutService _scheduleOutService;

        public ScheduleJsonOutController(IScheduleOutService scheduleOutService)
        {
            _scheduleOutService = scheduleOutService;
        }

        [HttpGet("{projectId}")]
        public async Task<ApiResponse<IList<ScheduleOut>>> GetSchedulesByProjectId(string projectId)
        {
            var data = await _scheduleOutService.GetByProjectIdAsync(projectId);
            return data.ToList();
        }

        [HttpGet]
        [Route("/api/schedule-out-file/{projectId}")]
        public async Task<IActionResult> DownloadScheduleOutAsync(string projectId)
        {
            var data = await _scheduleOutService.GetByProjectIdAsync(projectId);
            dynamic jsonObject = new ExpandoObject();
            jsonObject.data = data;
            var jsonData = JsonConvert.SerializeObject(jsonObject);

            var memStream = new MemoryStream(Encoding.ASCII.GetBytes(jsonData));
            return File(memStream, "application/octet-stream", "schedule.json");
        }
    }
}
