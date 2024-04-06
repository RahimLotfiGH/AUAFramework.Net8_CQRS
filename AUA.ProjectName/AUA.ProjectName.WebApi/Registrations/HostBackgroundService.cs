using AUA.ProjectName.BackgroundServices.DomainEventHandlers.AuditLog;
using AUA.ProjectName.BackgroundServices.DomainEventHandlers.DomainEventHandler;

namespace AUA.ProjectName.WebApi.Registrations;

public static class BackgroundHostService
{
    public static void RegistrationBackgroundService(this IServiceCollection services)
    {

        services.AddHostedService<DomainEventHandlers>();

        services.AddHostedService<FullAuditLogDomainEventHandlers>();

        services.AddHostedService<AuditLogDomainEventHandlers>();

        
    }

}