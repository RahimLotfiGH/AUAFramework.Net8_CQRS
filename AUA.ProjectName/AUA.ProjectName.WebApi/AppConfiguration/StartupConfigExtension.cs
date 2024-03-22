using AUA.ProjectName.WebApi.AppConfiguration.ConfigSwagger;
using AUA.ProjectName.WebApi.Registrations;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AUA.ProjectName.WebApi.AppConfiguration
{
    public static class StartupConfigExtension
    {
        public static void Configuration(this IServiceCollection services)
        {
            services.RegistrationAutoMapper();

            services.RegistrationServices();

            services.ConfigurationMediatR();

            services.CookieConfig();

            services.AddJwtAuthentication();

            services.AddCustomApiVersion();

            services.SwaggerConfig();

            services.AddCors();

            services.AddControllers();


            //Should be last line of registration
            services.RegistrationIoc();
        }


        private static void CookieConfig(this IServiceCollection services)
        {
            services
                .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();
        }

  
    }
}

