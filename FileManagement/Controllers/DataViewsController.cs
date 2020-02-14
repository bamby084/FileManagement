using FileManagement.Infrastructure;
using FileManagement.Infrastructure.Swagger;
using FileManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace FileManagement.Controllers
{
    [Route("api/views")]
    [ApiExplorerSettings(IgnoreApi = true)]
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
        [RequireViewAccessTokenHeader("GetViewData")]
        [SwaggerHeader("Access-Token")]
        public async Task<IActionResult> GetViewDataAsync(string viewName)
        {
            var data = await _viewService.GetViewDataAsync(viewName);
            return new ContentResult()
            {
                Content = data,
                StatusCode = 200,
                ContentType = "application/xml"
            };
        }
    }
}
