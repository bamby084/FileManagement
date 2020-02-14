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
        protected const string AccessTokenHeader = "Access-Token";

        public string Key { get; set; }

        public RequireAccessTokenHeaderAttribute(string key)
        {
            Key = key;
        }

        public virtual void OnAuthorization(AuthorizationFilterContext context)
        {
            string accessToken = context.HttpContext.Request.Headers[AccessTokenHeader];
            var appSettings = (IOptions<AppSettings>)context.HttpContext.RequestServices.GetService(typeof(IOptions<AppSettings>));
            
            if(accessToken.IsNull() || accessToken != appSettings.Value.PrivateAccessTokens.GetToken(Key))
            {
                context.Result = new EmptyUnauthorizedResult();
            }
        }

        protected class EmptyUnauthorizedResult : ActionResult
        {
            public override void ExecuteResult(ActionContext context)
            {
                context.HttpContext.Response.Headers.Add("www-authenticate", AccessTokenHeader);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
        }
    }
}
