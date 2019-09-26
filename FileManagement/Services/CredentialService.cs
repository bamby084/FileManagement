using FileManagement.Common.Services;
using FileManagement.ExtensionMethods;
using Microsoft.AspNetCore.Http;

namespace FileManagement.Services
{
    public class CredentialService : ICredentialService
    {
        private IHttpContextAccessor _httpContextAccessor;

        public CredentialService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentUserId()
        {
            return _httpContextAccessor.HttpContext.GetUserId();
        }
    }
}
