using System;
using System.Threading.Tasks;
using FileManagement.DataAccess.Entities;
using Microsoft.AspNetCore.Http;

namespace FileManagement.Services
{
    public interface IFileService
    {
        Task<string> GetFileAsync(Guid userId, string fileName, string fileType);
        Task<byte[]> GetFileAsBytesAsync(Guid userId, string fileName, string fileType);
        Task UploadFile(UserFile fileInfo);
        UserFile GetFileFromRequest(IFormFile file, Guid userId, string fileName = null);
    }
}
