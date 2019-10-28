using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Threading.Tasks;

namespace FileManagement.DataAccess
{
    public class RawQueryRepository : IRawQueryRepository
    {
        private DbContext _dbContext;
        public RawQueryRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DataTable> ExecuteSqlAsync(string query, params object[] parameters)
        {
            using(var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;
                
                if(parameters != null && parameters.Length > 0)
                {
                    command.Parameters.AddRange(parameters);
                }

                _dbContext.Database.OpenConnection();
                var dataReader = await command.ExecuteReaderAsync();
                var result = new DataTable();
                result.Load(dataReader);
                
                return result;
            }
        }
    }
}
