using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagement.Common.Exceptions;
using FileManagement.DataAccess;
using FileManagement.DataAccess.Entities;
using FileManagement.ExtensionMethods;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace FileManagement.Services
{
    public class FileService : IFileService
    {
        private readonly IRepository<UserFile> _fileRepository;
        
        public FileService(IRepositoryFactory repositoryFactory)
        {
            _fileRepository = repositoryFactory.CreateRepository<UserFile>();
        }

        public async Task UploadFile(UserFile fileInfo)
        {
            fileInfo.Id = Guid.NewGuid();
            await _fileRepository.AddAsync(fileInfo);
            await _fileRepository.SaveChangesAsync();
        }

        public async Task<string> GetFileAsync(Guid userId, string fileName)
        {
            byte[] content = await GetFileAsBytesAsync(userId, fileName);
            return Encoding.ASCII.GetString(content);
        }

        public UserFile GetFileFromRequest(IFormFile formFile, Guid userId, string fileName = null)
        {
            if (formFile == null)
            {
                var errors = new List<string>() { "Invalid file." };
                throw new ValidationException(errors);
            }

            if (string.IsNullOrEmpty(fileName))
                fileName = formFile.FileName;

            using (var memStream = new MemoryStream())
            {
                formFile.CopyTo(memStream);
                var file = new UserFile()
                {
                    UserId = userId,
                    FileName = fileName,
                    FileContent = memStream.ToArray()
                };

                return file;
            }
        }

        public async Task<byte[]> GetFileAsBytesAsync(Guid userId, string fileName)
        {
            var file = await FindFile(userId, fileName);
            if (file == null)
                throw new NotFoundException("File not found.");

            return file.FileContent;
        }

        private async Task<UserFile> FindFile(Guid userId, string fileName)
        {
            return await _fileRepository.AsQueryable()
                .Where(f => f.UserId == userId && f.FileName.EqualsIgnoreCase(fileName))
                .OrderByDescending(f => f.CreatedOn).FirstOrDefaultAsync();
        }
    }
}
