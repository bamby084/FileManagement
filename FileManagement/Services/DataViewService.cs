using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileManagement.Common.Exceptions;
using FileManagement.DataAccess;
using FileManagement.ExtensionMethods;
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

        public async Task<string> GetViewDataAsync(string viewName)
        {
            var viewDefinition = _viewDefitions.FirstOrDefault(view => view.Alias.EqualsIgnoreCase(viewName));
            if (viewDefinition == null)
            {
                throw new NotFoundException("View does not exist.");
            }

            var dataTable = await _rawQueryRepository.ExecuteSqlAsync($"SELECT * FROM {viewDefinition.Name}");
            dataTable.TableName = viewDefinition.EntryName ?? viewDefinition.Name;

            if (viewDefinition.Columns != null)
            {
                foreach (var columnDefinition in viewDefinition.Columns)
                {
                    dataTable.Columns[columnDefinition.Name].ColumnName = columnDefinition.Alias;
                }
            }

            var dataSet = new DataSet();
            dataSet.DataSetName = viewDefinition.RootName;
            dataSet.Tables.Add(dataTable);

            using (var memStream = new MemoryStream())
            {
                dataSet.WriteXml(memStream);
                memStream.Seek(0, SeekOrigin.Begin);
                return Encoding.UTF8.GetString(memStream.ToArray());
            }
        }
    }
}
