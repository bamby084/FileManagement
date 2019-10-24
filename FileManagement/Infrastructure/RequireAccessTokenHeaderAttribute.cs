using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using FileManagement.ExtensionMethods;
using System.Net;

namespace FileManagement.Infrastructure
{
    public class RequireAccessTokenHeaderAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private const string AccessTokenHeader = "Access-Token";

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string accessToken = context.HttpContext.Request.Headers[AccessTokenHeader];
            var appSettings = (IOptions<AppSettings>)context.HttpContext.RequestServices.GetService(typeof(IOptions<AppSettings>));
            
            if(accessToken.IsNull() || !accessToken.Equals(appSettings.Value.PrivateAccessToken))
            {
                context.Result = new EmptyUnauthorizedResult();
            }
        }

        private class EmptyUnauthorizedResult : ActionResult
        {
            public override void ExecuteResult(ActionContext context)
            {
                context.HttpContext.Response.Headers.Add("www-authenticate", AccessTokenHeader);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
        }
    }
}
