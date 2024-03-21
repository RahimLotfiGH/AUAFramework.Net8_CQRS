using AUA.ProjectName.Services.GeneralService.Login.Contracts;
using AUA.ProjectName.Services.GeneralService.Login.Services;

namespace AUA.ProjectName.WebApi.Registrations
{
    public static class GeneralService
    {
        public static void RegistrationGeneralServices(this IServiceCollection services)
        {

            services.RegistrationAccessServices();

        }

        private static void RegistrationAccessServices(this IServiceCollection services)
        {
            services.AddScoped<IAccessTokenService, AccessTokenService>();
            services.AddScoped<IGenerateJwtService, GenerateJwtService>();
        }

    

    }
}
