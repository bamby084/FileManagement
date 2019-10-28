
using FileManagement.Infrastructure;
using System.Threading.Tasks;

namespace FileManagement.Services
{
    public interface IDataViewService
    {
        Task<object> GetViewDataAsync(ViewDefinition viewDefinition );
    }
}
