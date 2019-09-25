using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using FileManagement.DataAccess.Entities;
using FileManagement.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace FileManagement.Services
{
    public class TokenService: ITokenService
    {
        private readonly AppSettings _appSettings;

        public TokenService(IOptions<AppSettings> options)
        {
            _appSettings = options.Value;
        }

        string ITokenService.GenerateJwt(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                }),
                Issuer = "File Management Service",
                Expires = DateTime.UtcNow.AddMinutes(_appSettings.AccessTokenLifeTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateEncodedJwt(tokenDescriptor);
            return token;
        }
    }
}
