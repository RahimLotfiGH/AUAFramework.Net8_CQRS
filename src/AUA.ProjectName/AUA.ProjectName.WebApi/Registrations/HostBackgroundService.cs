using AUA.ProjectName.BackgroundServices.DomainEventHandlers.Accounting;
using AUA.ProjectName.BackgroundServices.DomainEventHandlers.AppUsers;
using AUA.ProjectName.BackgroundServices.DomainEventHandlers.AuditLog;
using AUA.ProjectName.BackgroundServices.DomainEventHandlers.General;

namespace AUA.ProjectName.WebApi.Registrations;

public static class BackgroundHostService
{
    public static void RegistrationBackgroundService(this IServiceCollection services)
    {

        services.AddHostedService<AccountingDomainEventHandlers>();

        services.AddHostedService<ActionDomainEventHandlers>();

        services.AddHostedService<FullAuditLogDomainEventHandlers>();

        services.AddHostedService<AuditLogDomainEventHandlers>();

        services.AddHostedService<CreatedAppUserDomainEventHandlers>();

        services.AddHostedService<CreatedAccountDomainEventHandlers>();
        




    }

}