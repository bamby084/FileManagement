using System.Threading.Tasks;
using FileManagement.DataAccess.Entities;
using Microsoft.AspNetCore.Http;

namespace FileManagement.Services
{
    public interface IFileService
    {
        Task<string> GetFileAsync(string fileName, string fileType);
        Task<byte[]> GetFileAsBytesAsync(string fileName, string fileType);
        Task UploadFile(FileIn fileInfo);
        FileIn GetFileFromRequest(IFormFile file, string fileName = null);
    }
}
