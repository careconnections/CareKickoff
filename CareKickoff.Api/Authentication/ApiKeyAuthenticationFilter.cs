using System.Collections.Generic;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace CareKickoff.Api.Authentication {
    public class ApiKeyAuthenticationFilter : IOperationFilter {
        public void Apply(Operation operation, OperationFilterContext context) {
            if (operation.Parameters == null)
                operation.Parameters = new List<IParameter>();

            operation.Parameters.Add(new NonBodyParameter {
                Name = ApiKeyAuthenticationSettings.ApiKeyHeaderName,
                In = "header",
                Type = "string",
                Required = true
            });
        }
    }
}