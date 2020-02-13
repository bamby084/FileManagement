using System.Threading.Tasks;

namespace FileManagement.Services
{
    public interface IDataViewService
    {
        Task<string> GetViewDataAsync(string viewName);
    }
}
