using System.IO;
using FileManagement.Infrastructure;
using FileManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FileManagement.Controllers
{
    [Route("api/schedule-file")]
    public class ScheduleFileController: ApiController
    {
        private readonly IFileService _fileService;
        
        public ScheduleFileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("{fileName}/content")]
        public async Task<ApiResponse<string>> GetFileContentAsync(string fileName)
        {
            return await _fileService.GetFileAsync(UserId, fileName);
        }

        [HttpGet("{fileName}")]
        public async Task<IActionResult> DownloadFileAsync(string fileName)
        {
            byte[] content = await _fileService.GetFileAsBytesAsync(UserId, fileName);

            var memStream = new MemoryStream(content);
            return File(memStream, "application/octet-stream", fileName);
        }

        [HttpPost]
        public async Task<ApiResponse> UploadFile(IFormFile formFile, string fileName)
        {
            var file = _fileService.GetFileFromRequest(formFile, UserId, fileName);
            file.FileType = "Schedule";
            
            await _fileService.UploadFile(file);
            return ApiResponse.NoContent;
        }
    }
}
