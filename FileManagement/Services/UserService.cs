using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileManagement.Common.Exceptions;
using FileManagement.DataAccess;
using FileManagement.DataAccess.Entities;
using FileManagement.ExtensionMethods;

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

        public async Task<IList<User>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.ToList();
        }

        public async Task<string> GetTokenAsync(string userName, string secret)
        {
            var users = await _userRepository.FindAsync(
                u => u.Email.EqualsIgnoreCase(userName) && u.ApiSecret.EqualsIgnoreCase(secret));

            var user = users.FirstOrDefault();
            if (user == null)
                throw new NotFoundException("Invalid email or secret key.");

            string token = _tokenService.GenerateJwt(user);
            return await Task.FromResult(token);
        }
    }
}
