using System;
using System.IO;
using FileManagement.Infrastructure;
using FileManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FileManagement.ExtensionMethods;
using Microsoft.AspNetCore.Http;

namespace FileManagement.Controllers
{
    [Route("api/file")]
    public class FileController: ApiController
    {
        private readonly IFileService _fileService;
        
        public FileController(IFileService fileService, ITokenService tokenService)
        {
            _fileService = fileService;
        }

        [HttpGet("{fileName}/content")]
        public async Task<ApiResponse<string>> GetFileContentAsync(string fileName)
        {
            Guid userId = Request.GetUserId();
            return await _fileService.GetFileAsync(userId, fileName);
        }

        [HttpGet("{fileName}")]
        public async Task<IActionResult> DownloadFileAsync(string fileName)
        {
            Guid userId = Request.GetUserId();
            byte[] content = await _fileService.GetFileAsBytesAsync(userId, fileName);

            var memStream = new MemoryStream(content);
            return File(memStream, "application/octet-stream", fileName);
        }

        [HttpPost]
        public async Task<ApiResponse> UploadFile(IFormFile formFile, string fileName)
        {
            Guid userId = Request.GetUserId();
            var file = _fileService.GetFileFromRequest(formFile, userId, fileName);
            await _fileService.UploadFile(file);

            return ApiResponse.NoContent;
        }
    }
}
