using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IRepository<FileIn> _fileRepository;
        
        public FileService(IRepositoryFactory repositoryFactory)
        {
            _fileRepository = repositoryFactory.CreateRepository<FileIn>();
        }

        public async Task UploadFile(FileIn fileInfo)
        {
            fileInfo.Id = Guid.NewGuid();
            await _fileRepository.AddAsync(fileInfo);
            await _fileRepository.SaveChangesAsync();
        }

        public async Task<string> GetFileAsync(string fileName, string fileType)
        {
            byte[] content = await GetFileAsBytesAsync(fileName, fileType);
            return Encoding.ASCII.GetString(content);
        }

        public FileIn GetFileFromRequest(IFormFile formFile,  string fileName = null)
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
                var file = new FileIn()
                {
                    FileName = fileName,
                    FileContent = memStream.ToArray()
                };

                return file;
            }
        }

        public async Task<byte[]> GetFileAsBytesAsync(string fileName, string fileType)
        {
            var file = await FindFile(fileName, fileType);
            if (file == null)
                throw new NotFoundException("File not found.");

            return file.FileContent;
        }

        private async Task<FileIn> FindFile(string fileName, string fileType)
        {
            return await _fileRepository.AsQueryable()
                .Where(f => f.FileName.EqualsIgnoreCase(fileName)
                            && f.FileType.EqualsIgnoreCase(fileType))
                .OrderByDescending(f => f.CreatedOn).FirstOrDefaultAsync();
        }
    }
}
