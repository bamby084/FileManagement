using System.Data;
using System.Threading.Tasks;

namespace FileManagement.DataAccess
{
    public interface IRawQueryRepository
    {
        Task<DataTable> ExecuteSqlAsync(string query, params object[] parameters);
    }
}
