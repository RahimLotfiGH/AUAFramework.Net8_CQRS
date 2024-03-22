using AUA.Infrastructure.PipelineBehaviors.Behaviors;
using AUA.ProjectName.CommandHandler.Utilities;
using AUA.ProjectName.Infrastructure.PipelineBehaviors.Behaviors;
using AUA.ProjectName.QueryHandler.Utilities;
using AUA.ProjectName.ReportHandler.Utilities;
using MediatR;

namespace AUA.ProjectName.WebApi.AppConfiguration
{
    public static class MediatRConfiguration
    {
        public static void ConfigurationMediatR(this IServiceCollection services)
        {
            services.RegistrationHandler();

            services.RegistrationPipeline();

        }
        private static void RegistrationHandler(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ICommandHandlerPathHelper).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(IQueryHandlerPathHelper).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(IReportHandlerPathHelper).Assembly));

        }

        private static void RegistrationPipeline(this IServiceCollection services)
        {
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FullAuditLogBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuditLogBehaviour<,>));
        }

    }
}
