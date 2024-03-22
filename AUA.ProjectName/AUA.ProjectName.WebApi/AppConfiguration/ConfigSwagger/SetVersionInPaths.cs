using AUA.ProjectName.Common.Consts;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AUA.ProjectName.WebApi.AppConfiguration.ConfigSwagger
{
    public class SetVersionInPaths : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            swaggerDoc.Paths = CreateVersionPath(swaggerDoc);
        }

        private static OpenApiPaths CreateVersionPath(OpenApiDocument swaggerDoc)
        {
            var openApiPaths = new OpenApiPaths();

            foreach (var entry in swaggerDoc.Paths)
                openApiPaths.Add(
                     entry.Key.Replace(SwaggerConsts.VersionPathFormat, swaggerDoc.Info.Version),
                     entry.Value);

            return openApiPaths;
        }
    }
}
