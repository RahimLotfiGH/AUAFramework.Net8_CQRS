using AUA.Infrastructure.Utilities.ServiceUtilities;

namespace AUA.ProjectName.WebApi.Registrations
{
    public static class StartUpServices
    {
        public static void RegistrationServices(this IServiceCollection services)
        {
            services.RegistrationDatabaseService();

            services.RegistrationGeneralServices();

            services.RegistrationToStaticIoc();

            services.RegistrationReportService();

            services.RegistrationDomainEvents();

            services.RegistrationBackgroundService();

        }


        public static void RegistrationToStaticIoc(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            AppServiceFactory.SetServiceProvider(serviceProvider);

        }

    }
}
