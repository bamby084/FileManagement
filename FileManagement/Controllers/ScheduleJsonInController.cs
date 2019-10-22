using System.Text;
using System.Threading.Tasks;
using FileManagement.DataAccess.Entities;
using FileManagement.Infrastructure;
using FileManagement.Models;
using FileManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FileManagement.Controllers
{
    [Route("api/schedule-in")]
    public class ScheduleJsonInController : ApiController
    {
        private const string FileType = "ScheduleJson";
        private const string FileName = "Schedule.json";

        private readonly IFileService _fileService;

        public ScheduleJsonInController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        public async Task<ApiResponse> UploadSchedule([FromBody]ScheduleIn schedule)
        {
            string fileContent = JsonConvert.SerializeObject(schedule);

            var file = new FileIn();
            file.FileName = FileName;
            file.FileType = FileType;
            file.FileContent = Encoding.ASCII.GetBytes(fileContent);

            await _fileService.UploadFile(file);
            return ApiResponse.NoContent;
        }

        [HttpGet]
        public async Task<ApiResponse<ScheduleIn>> GetSchedule()
        {
            var fileContent = await _fileService.GetFileAsync(FileName, FileType);
            return JsonConvert.DeserializeObject<ScheduleIn>(fileContent);
        }
    }
}
