using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace FileManagement.Infrastructure.Swagger
{
    public class SwaggerFileUploadOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            var swaggerFileUploadAttribute = context.MethodInfo.GetCustomAttribute<SwaggerFileUploadAttribute>();
            if (swaggerFileUploadAttribute == null)
                return;

            operation.Parameters.Add(new NonBodyParameter
            {
                Name = "uploadedFile",
                In = "formData",
                Description = "Upload File",
                Required = true,
                Type = "file"
            });

            operation.Consumes.Add("multipart/form-data");
        }
    }
}
