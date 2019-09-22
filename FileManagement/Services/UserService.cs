using System.Linq;
using System.Threading.Tasks;
using FileManagement.Common.Exceptions;
using FileManagement.DataAccess;
using FileManagement.DataAccess.Entities;
using FileManagement.ExtensionMethods;
using Microsoft.AspNetCore.Authorization;

namespace FileManagement.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly ITokenService _tokenService;

        public UserService(IRepositoryFactory repositoryFactory, ITokenService tokenService)
        {
            _userRepository = repositoryFactory.CreateRepository<User>();
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        public async Task<string> GetTokenAsync(string userName, string password)
        {
            var users = await _userRepository.FindAsync(
                u => u.Email.EqualsIgnoreCase(userName) && u.Password.EqualsIgnoreCase(password));

            var user = users.FirstOrDefault();
            if (user == null)
                throw new NotFoundException("Invalid email or password.");

            string token = _tokenService.GenerateJwt(user);
            return await Task.FromResult(token);
        }
    }
}
