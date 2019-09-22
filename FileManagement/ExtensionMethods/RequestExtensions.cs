using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace FileManagement.ExtensionMethods
{
    public static class RequestExtensions
    {
        public static Guid GetUserId(this HttpRequest request)
        {
            string token = request.Headers["Authorization"];
            token = token.Substring(7); //remove Bearer

            var jwtToken = new JwtSecurityToken(token);
            var userIdClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "unique_name");

            if (userIdClaim == null)
                return Guid.Empty;

            return Guid.Parse(userIdClaim.Value);
        }
    }
}
