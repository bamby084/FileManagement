using System;
using System.Threading.Tasks;
using FileManagement.DataAccess.Entities;
using Microsoft.AspNetCore.Http;

namespace FileManagement.Services
{
    public interface IFileService
    {
        Task<string> GetFileAsync(Guid userId, string fileName);
        Task<byte[]> GetFileAsBytesAsync(Guid userId, string fileName);
        Task UploadFile(UserFile fileInfo);
        UserFile GetFileFromRequest(IFormFile file, Guid userId, string fileName = null);
    }
}
