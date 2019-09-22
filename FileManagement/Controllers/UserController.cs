using System.Threading.Tasks;
using FileManagement.Infrastructure;
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
        [HttpGet("token")]
        public async Task<ApiResponse<string>> GetTokenAsync(string email, string password)
        {
            return await _userService.GetTokenAsync(email, password);
        }
    }
}
