using AUA.Infrastructure.Registrations;
using AUA.ProjectName.DataLayer.AppContext.EntityFrameworkContext;
using AUA.ProjectName.Services.Utilities;

namespace AUA.ProjectName.WebApi.Registrations
{
    public static class RegistrationDomainService
    {
        public static void RegistrationDatabaseService(this IServiceCollection services)
        {
            services.RegistrationBaseService();

            services.RegistrationEntitiesService();

            services.RegistrationReportService();
        }

        private static void RegistrationBaseService(this IServiceCollection services)
        {
            services.AddDbContext<IUnitOfWork, ApplicationEfContext>();
        }

        private static void RegistrationEntitiesService(this IServiceCollection services)
        {
            services.RegistrationEntityServices(typeof(IServicePathHelper));

        }

        public static void RegistrationReportService(this IServiceCollection services)
        {
            services.RegistrationReportServices(typeof(IServicePathHelper));
        }


    }
}
