using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.WebApi.Utility.ApiAuthorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AUA.ProjectName.WebApi.AppConfiguration.ConfigSwagger
{
    public class AuthorizeOperationFilter : IOperationFilter
    {

        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (HasAnonymous(context) || !IsAuthorized(context)) return;

            SetSecurityRequirement(operation);

        }

        private static void SetSecurityRequirement(OpenApiOperation operation)
        {
            operation.Security = CreateSecurityRequirement();
        }

        private static IList<OpenApiSecurityRequirement> CreateSecurityRequirement()
        {
            return new List<OpenApiSecurityRequirement>
            {
                CreateOpenApiSecurityRequirement()
            };
        }

        private static bool HasAnonymous(OperationFilterContext context)
        {
            var filterAttributes = context.MethodInfo.CustomAttributes;

            return filterAttributes.Any(p => p.AttributeType.Name ==
                                                         nameof(AllowAnonymousAttribute));
        }

        private static bool IsAuthorized(OperationFilterContext context)
        {
            return context.MethodInfo.DeclaringType != null &&
                   (context.MethodInfo.DeclaringType.GetCustomAttributes(true).OfType<WebApiAuthorizeAttribute>().Any() ||
                    context.MethodInfo.GetCustomAttributes(true).OfType<WebApiAuthorizeAttribute>().Any());
        }

        private static OpenApiSecurityRequirement CreateOpenApiSecurityRequirement()
        {
            return new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Name = BearerTokensOptionsConsts.SchemeName,
                        Scheme = BearerTokensOptionsConsts.SchemeName,
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.Http,
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = BearerTokensOptionsConsts.SchemeName
                        }
                    },
                    new List<string>()
                }
            };
        }


    }
}
