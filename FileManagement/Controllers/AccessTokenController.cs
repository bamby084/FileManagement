using FileManagement.Infrastructure;
using FileManagement.Models;
using FileManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FileManagement.Controllers
{
    [Route("api/access-token")]
    public class AccessTokenController: ApiController
    {
        private readonly IUserService _userService;
        public AccessTokenController(IUserService userService)
        {
            _userService = userService;
        }

        //api/access-token
        [AllowAnonymous]
        [HttpPost]
        public async Task<ApiResponse<string>> GetTokenAsync([FromBody]Credentials credentials)
        {
            return await _userService.GetTokenAsync(credentials.Email, credentials.SecretKey);
        }
    }
}
