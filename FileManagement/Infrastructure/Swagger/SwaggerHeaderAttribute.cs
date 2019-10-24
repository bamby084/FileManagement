using System;

namespace FileManagement.Infrastructure.Swagger
{
    [AttributeUsage(AttributeTargets.Method)]
    public class SwaggerHeaderAttribute: Attribute
    {
        public string Header { get; set; }

        public SwaggerHeaderAttribute(string header)
        {
            Header = header;
        }
    }
}
