using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace FileManagement.ExtensionMethods
{
    public static class RequestExtensions
    {
        public static string GetUserId(this HttpContext context)
        {
            var userNameClaim = context.User.FindFirst(ClaimTypes.Name);
            return userNameClaim?.Value.ToUpper();
        }
    }
}
