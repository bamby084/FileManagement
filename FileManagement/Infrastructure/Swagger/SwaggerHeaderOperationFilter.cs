using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Reflection;

namespace FileManagement.Infrastructure.Swagger
{
    public class SwaggerHeaderOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();

            var swaggerHeader = context.MethodInfo.GetCustomAttribute<SwaggerHeaderAttribute>();
            if (swaggerHeader == null)
                return;

            operation.Parameters.Add(new NonBodyParameter()
            {
                Name = swaggerHeader.Header,
                In = "header",
                Type = "string",
                Required = true
            });
        }
    }
}
