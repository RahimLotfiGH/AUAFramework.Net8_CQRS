using AUA.Infrastructure.Utilities.ServiceUtilities;

namespace AUA.ProjectName.WebApi.Registrations
{
    public static class RegistrationAppIoc
    {
        public static void RegistrationIoc(this IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();

            AppServiceFactory.SetServiceProvider(serviceProvider);

        }

    }
}
