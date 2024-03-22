using System.Text;
using AUA.ProjectName.Common.Tools.Config.JsonSetting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.IdentityModel.Tokens;

namespace AUA.ProjectName.WebApi.AppConfiguration
{
    public static class JwtAuthenticationExtensions
    {
        public static void AddJwtAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var secretkey = Encoding.UTF8.GetBytes(AccessTokenSetting.SecretKey);
                var encryptionkey = Encoding.UTF8.GetBytes(AccessTokenSetting.EncryptionKey);

                var validationParameters = new TokenValidationParameters
                {
                    ClockSkew = TimeSpan.Zero, // default: 5 min
                    RequireSignedTokens = true,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretkey),

                    RequireExpirationTime = true,
                    ValidateLifetime = true,

                    ValidateAudience = true, //default : false
                    ValidAudience = AccessTokenSetting.Audience,

                    ValidateIssuer = true, //default : false
                    ValidIssuer = AccessTokenSetting.Issuer,
                    TokenDecryptionKey = new SymmetricSecurityKey(encryptionkey),

                };

                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = validationParameters;
                options.Events = new JwtBearerEvents
                {
                };

            });
        }


        public static void AddCustomApiVersion(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
               
                options.AssumeDefaultVersionWhenUnspecified = true; 
                options.DefaultApiVersion = new ApiVersion(1, 0); //v1.0 == v1
                options.ReportApiVersions = true;

                ApiVersion.TryParse("1.0", out var version10);
                ApiVersion.TryParse("1", out var version1);
                var a = version10 == version1;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
              
            });
        }
    }
}
