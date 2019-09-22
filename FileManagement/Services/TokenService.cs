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
        private readonly string _secretKey;

        public TokenService(IOptions<AppSettings> appSettings)
        {
            _secretKey = appSettings.Value.Secret;
        }

        string ITokenService.GenerateJwt(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secretKey);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateEncodedJwt(tokenDescriptor);
            return token;
        }
    }
}
