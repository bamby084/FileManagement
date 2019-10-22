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

        [HttpGet]
        public async Task<ApiResponse<IList<ScheduleOut>>> GetSchedules()
        {
            var data = await _scheduleOutService.GetAllAsync();
            return data.ToList();
        }

        [HttpGet]
        [Route("/api/schedule-out-file")]
        public async Task<IActionResult> DownloadScheduleOutAsync()
        {
            var data = await _scheduleOutService.GetAllAsync();
            dynamic jsonObject = new ExpandoObject();
            jsonObject.data = data;
            var jsonData = JsonConvert.SerializeObject(jsonObject);

            var memStream = new MemoryStream(Encoding.ASCII.GetBytes(jsonData));
            return File(memStream, "application/octet-stream", "schedule.json");
        }
    }
}
