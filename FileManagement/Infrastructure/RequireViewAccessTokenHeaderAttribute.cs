using FileManagement.ExtensionMethods;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;

namespace FileManagement.Infrastructure
{
    public class RequireViewAccessTokenHeaderAttribute : RequireAccessTokenHeaderAttribute
    {
        public RequireViewAccessTokenHeaderAttribute(string key)
            : base(key)
        {
        }

        public override void OnAuthorization(AuthorizationFilterContext context)
        {
            string accessToken = context.HttpContext.Request.Headers[AccessTokenHeader];
            var appSettings = (IOptions<AppSettings>)context.HttpContext.RequestServices.GetService(typeof(IOptions<AppSettings>));
            var viewDefitions = (IOptions<ViewDefinitions>)context.HttpContext.RequestServices.GetService(typeof(IOptions<ViewDefinitions>));
            
            if (accessToken.IsNull() || accessToken != appSettings.Value.PrivateAccessTokens.GetToken(Key))
            {
                context.Result = new EmptyUnauthorizedResult();
            }
        }
    }
}
