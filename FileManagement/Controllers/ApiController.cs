using FileManagement.ExtensionMethods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FileManagement.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiController: ControllerBase
    {
        public Guid UserId => Guid.Parse(HttpContext.GetUserId());
    }
}
