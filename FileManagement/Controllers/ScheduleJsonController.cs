using FileManagement.DataAccess.Entities;
using FileManagement.Infrastructure;
using FileManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;

namespace FileManagement.Controllers
{
    [Route("api/schedule-json")]
    public class ScheduleJsonController: ApiController
    {
        private readonly IFileService _fileService;

        public ScheduleJsonController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost]
        [Consumes("text/plain")]
        public async Task<ApiResponse> Schedule([FromBody]string content)
        {
            var file = new UserFile();
            file.UserId = UserId;
            file.FileName = "Schedule.json";
            file.FileType = "ScheduleJson";
            file.FileContent = Encoding.ASCII.GetBytes(content);

            await _fileService.UploadFile(file);
            return ApiResponse.NoContent;
        }
    }
}
