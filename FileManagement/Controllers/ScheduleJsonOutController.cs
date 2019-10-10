using FileManagement.Infrastructure;
using FileManagement.Models;
using FileManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

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
    }
}
