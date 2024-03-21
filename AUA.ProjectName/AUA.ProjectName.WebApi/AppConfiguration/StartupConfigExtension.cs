using AUA.ProjectName.Common.Consts;
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

            //services.SessionConfig(); //Not recommend
            services.AddJwtAuthentication();

            services.AddCustomApiVersioning();

            services.MvcConfig();

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

        private static void SessionConfig(this IServiceCollection services)
        {
            services.AddSession(options =>
            {
                options.Cookie.Name = AppConsts.CookieName;
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.IsEssential = true;
            });
        }

        private static void MvcConfig(this IServiceCollection services)
        {
          //  services.AddControllersWithViews();
                    //.AddNewtonsoftJson(options => options
                    //        .SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        }

        //private static void SwaggerConfig(this IServiceCollection services)
        //{
            
        //    services.AddSwaggerGen(options =>
        //    {
        //        options.SwaggerDoc(SwaggerConsts.VersionV1,
        //                           new OpenApiInfo
        //                           {
        //                               Title = SwaggerConsts.Title,
        //                               Version = SwaggerConsts.VersionV1
        //                           });

        //        options.OperationFilter<SwaggerRequiredParameters>();


        //        //options.OperationFilter<CustomOperationFilter>();
        //    });
        //}
    }
}

