using AspNet_Api_EfCore.Configurations;
using AspNet_Api_EfCore.ValueObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AspNet_Api_EfCore.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAttribute : System.Attribute, IAsyncActionFilter
    {

        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {

            JWTSettings jwtSettings = AppSettingsConfig.Configuration.GetSection("JWTSettings").Get<JWTSettings>();

            if (!context.HttpContext.Request.Query.TryGetValue(jwtSettings.ApiKeyName, out var extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "ApiKey não encontrada"
                };
                return;
            }

            string apiKey = AppSettingsConfig.Configuration.GetValue<string>("ApiKey");
            if (!jwtSettings.ApiKey.Equals(extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 403,
                    Content = "Acesso não autorizado"
                };
                return;
            }

            await next();
        }
    }
}
