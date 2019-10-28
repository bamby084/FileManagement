using System.Threading.Tasks;
using FileManagement.DataAccess;
using FileManagement.Infrastructure;
using Microsoft.Extensions.Options;

namespace FileManagement.Services
{
    public class DataViewService: IDataViewService
    {
        private readonly ViewDefinitions _viewDefitions;
        private readonly IRawQueryRepository _rawQueryRepository;
        public int Var { get; set; }
       
        public DataViewService(IOptions<ViewDefinitions> options, IRawQueryRepository rawQueryRepository)
        {
            _viewDefitions = options.Value;
            _rawQueryRepository = rawQueryRepository;
            Var = 10;
        }

        public async Task<object> GetViewDataAsync(ViewDefinition viewDefinition)
        {
            var result = await _rawQueryRepository.ExecuteSqlAsync("SELECT * FROM APITimesheetKSA");
            return result;
        }
    }
}
