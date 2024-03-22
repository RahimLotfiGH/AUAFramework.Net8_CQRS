using AUA.ProjectName.Common.Consts;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AUA.ProjectName.WebApi.AppConfiguration.ConfigSwagger
{

    public class RemoveVersionParameters : IOperationFilter
    {
        public void Apply(OpenApiOperation apiOperation, OperationFilterContext context)
        {

            var versionParameter = GetApiParameter(apiOperation);

            if (versionParameter == null) return;

            apiOperation.Parameters.Remove(versionParameter);
        }

        private static OpenApiParameter? GetApiParameter(OpenApiOperation apiOperation)

        {
            return apiOperation
                   .Parameters
                   .SingleOrDefault(p => p.Name == SwaggerConsts.Version);

        }
    }
}
