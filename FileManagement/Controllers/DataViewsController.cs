using FileManagement.ExtensionMethods;
using FileManagement.Infrastructure;
using FileManagement.Infrastructure.Swagger;
using FileManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data;
using System.Dynamic;
using System.Threading.Tasks;
using System.Xml;

namespace FileManagement.Controllers
{
    [Route("api/views")]
    public class DataViewsController: ApiController
    {
        private readonly IDataViewService _viewService;
        public DataViewsController(IDataViewService viewService)
        {
            _viewService = viewService;
        }

        [HttpGet("{viewName}")]
        [Produces("application/xml")]
        [AllowAnonymous]
        //[RequireAccessTokenHeader]
        [SwaggerHeader("Access-Token")]
        public async Task<object> GetViewDataAsync(string viewName)
        {
            
            //var dt = new DataTable();
            //dt.TableName = "MyTable";
            //dt.Columns.Add("Name");
            //dt.Columns.Add("Age");

            //dt.Rows.Add("Hello", 1);
            //dt.Rows.Add("Hello2", 2);

            //var ds = new DataSet();
            //ds.DataSetName = "MyTables";
            //ds.Tables.Add(dt);
            //ds.WriteXml(@"c:\temp\my.xml");
            
            //return ds;
            var data = await _viewService.GetViewDataAsync(new ViewDefinition());
            //var result = JsonConvert.SerializeObject(data);
            //XmlDocument doc = JsonConvert.DeserializeXmlNode(result);
            return data;
        }
    }
}
