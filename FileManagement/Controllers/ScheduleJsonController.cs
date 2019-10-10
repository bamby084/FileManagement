using System.Text;
using System.Threading.Tasks;
using FileManagement.DataAccess.Entities;
using FileManagement.Infrastructure;
using FileManagement.Services;
using Microsoft.AspNetCore.Mvc;

namespace FileManagement.Controllers
{
    [Route("api/schedule-in")]
    public class ScheduleJsonController : ApiController
    {
        private const string FileType = "ScheduleJson";
        private const string FileName = "Schedule.json";

        private readonly IFileService _fileService;

        public ScheduleJsonController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        [Consumes("text/plain")]
        public async Task<ApiResponse> UploadSchedule([FromBody]string content)
        {
            var file = new FileIn();
            file.FileName = FileName;
            file.FileType = FileType;
            file.FileContent = Encoding.ASCII.GetBytes(content);

            await _fileService.UploadFile(file);
            return ApiResponse.NoContent;
        }

        [HttpGet]
        public async Task<ApiResponse<string>> GetSchedule()
        {
            return await _fileService.GetFileAsync(FileName, FileType);
        }
    }
}
