
using System.Threading.Tasks;

namespace FileManagement.Services
{
    public interface IUserService
    {
        Task<string> GetTokenAsync(string userName, string secret);
    }
}
