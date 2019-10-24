using AutoMapper;
using FileManagement.Infrastructure;
using FileManagement.Infrastructure.Swagger;
using FileManagement.Models;
using FileManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileManagement.Controllers
{
    [Route("api/users")]
    public class UsersController: ApiController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        [Produces("application/xml")]
        [AllowAnonymous]
        [RequireAccessTokenHeader]
        [SwaggerHeader("Access-Token")]
        public async Task<UserCollection> GetAllUsersAsync()
        {
            var users = await _userService.GetAllUsersAsync();
            var userCollection = new UserCollection(_mapper.Map<IList<XmlUser>>(users));

            return userCollection;
        }
    }
}
