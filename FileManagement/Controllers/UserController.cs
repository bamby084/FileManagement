using System.Threading.Tasks;
using FileManagement.Infrastructure;
using FileManagement.Models;
using FileManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FileManagement.Controllers
{
    [Route("api/user")]
    public class UserController: ApiController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //api/user/token
        [AllowAnonymous]
        [HttpPost("token")]
        public async Task<ApiResponse<string>> GetTokenAsync([FromBody]Credentials credentials)
        {
            return await _userService.GetTokenAsync(credentials.Email, credentials.SecretKey);
        }
    }
}
