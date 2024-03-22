using System.Reflection;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Common.Tools.Config.JsonSetting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AUA.ProjectName.WebApi.AppConfiguration.ConfigSwagger
{
    public static class SwaggerConfigurationExtensions
    {
        public static void SwaggerConfig(this IServiceCollection services)
        {

            services.AddSwaggerGen(options =>
            {
                var xmlDocPath = CreateXmlDocPath();

                options.IncludeXmlComments(xmlDocPath, true);

                options.EnableAnnotations();

                options.SwaggerDoc("v1", new OpenApiInfo { Version = ApiVersionConsts.V1, Title = "API V1" });
                options.SwaggerDoc("v2", new OpenApiInfo { Version = ApiVersionConsts.V2, Title = "API V2" });
                options.SwaggerDoc("v3", new OpenApiInfo { Version = ApiVersionConsts.V3, Title = "API V3" });

                options.OperationFilter<AuthorizeOperationFilter>();
               
                options.AddSecurityDefinition(BearerTokensOptionsConsts.SchemeName, CreateOpenApiSecurityScheme());

                options.OperationFilter<RemoveVersionParameters>();

                options.DocumentFilter<SetVersionInPaths>();

                options.DocInclusionPredicate((docName, apiDesc) =>
                {
                    if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

                    var versions = methodInfo.DeclaringType?
                        .GetCustomAttributes<ApiVersionAttribute>(true)
                        .SelectMany(attr => attr.Versions);

                    return versions!.Any(v => $"v{v}" == docName);
                });

            });
        }



        private static OpenApiSecurityScheme CreateOpenApiSecurityScheme()
        {
            return new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Name = BearerTokensOptionsConsts.TokenName,
                In = ParameterLocation.Header,

                Flows = new OpenApiOAuthFlows
                {
                    Password = new OpenApiOAuthFlow
                    {
                        TokenUrl = new Uri(AccessTokenSetting.LoginTokenUrl),
                        RefreshUrl = new Uri(AccessTokenSetting.RefreshTokenUrl),

                    }

                }

            };
        }
        private static string CreateXmlDocPath()
        {
            return Path.Combine(AppContext.BaseDirectory, SwaggerConsts.XmlCommentsFileName);
        }

        public static void UseSwaggerAndUI(this IApplicationBuilder app)
        {
            
            app.UseSwagger(options => { });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
                options.SwaggerEndpoint("/swagger/v2/swagger.json", "V2 Docs");
                options.SwaggerEndpoint("/swagger/v3/swagger.json", "V3 Docs");
            });
        }
    }
}
