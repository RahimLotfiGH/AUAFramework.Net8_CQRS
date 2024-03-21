using System.Threading.Channels;
using AUA.ProjectName.Models.DomainEvents.Accounting;
using AUA.ProjectName.Models.DomainEvents.AppUsers;
using AUA.ProjectName.Models.DomainEvents.AuditLog;
using AUA.ProjectName.Models.DomainEvents.General;

namespace AUA.ProjectName.WebApi.Registrations
{
    public static class DomainEvents
    {
        public static void RegistrationDomainEvents(this IServiceCollection services)
        {

            services.RegistrationAccountingDomainEvent();

            services.RegistrationCommandDomainEvent();

            services.RegistrationAuditLogDomainEvent();

            services.RegistrationFullAuditLogDomainEvent();

            services.RegistrationCreatedAccountDomainEventDomainEvent();

            services.RegistrationCreatedAppUserDomainEventDomainEvent();
        }

        private static void RegistrationAccountingDomainEvent(this IServiceCollection services)
        {
            var bus = Channel.CreateBounded<LoginDomainEvent>(new BoundedChannelOptions(10)
            {
                FullMode = BoundedChannelFullMode.Wait
            });

            services.AddSingleton(bus);
        }

        private static void RegistrationCommandDomainEvent(this IServiceCollection services)
        {
            var bus = Channel.CreateBounded<ActionDomainEvent>(new BoundedChannelOptions(1000)
            {
                FullMode = BoundedChannelFullMode.DropOldest
            });

            services.AddSingleton(bus);
        }

        private static void RegistrationFullAuditLogDomainEvent(this IServiceCollection services)
        {
            var bus = Channel.CreateBounded<FullAuditLogDomainEvent>(new BoundedChannelOptions(1000)
            {
                FullMode = BoundedChannelFullMode.DropOldest
            });

            services.AddSingleton(bus);
        }
        private static void RegistrationAuditLogDomainEvent(this IServiceCollection services)
        {
            var bus = Channel.CreateBounded<AuditLogDomainEvent>(new BoundedChannelOptions(1000)
            {
                FullMode = BoundedChannelFullMode.DropOldest
            });

            services.AddSingleton(bus);
        }

        private static void RegistrationCreatedAccountDomainEventDomainEvent(this IServiceCollection services)
        {
            var bus = Channel.CreateBounded<CreatedAccountDomainEvent>(new BoundedChannelOptions(1000)
            {
                FullMode = BoundedChannelFullMode.Wait
            });

            services.AddSingleton(bus);
        }

        private static void RegistrationCreatedAppUserDomainEventDomainEvent(this IServiceCollection services)
        {
            var bus = Channel.CreateBounded<CreatedAppUserDomainEvent>(new BoundedChannelOptions(1000)
            {
                FullMode = BoundedChannelFullMode.Wait
            });

            services.AddSingleton(bus);
        }
    }
}
