using System;
using FileManagement.DataAccess.Entities;

namespace FileManagement.Services
{
    public interface ITokenService
    {
        string GenerateJwt(User user);
    }
}
