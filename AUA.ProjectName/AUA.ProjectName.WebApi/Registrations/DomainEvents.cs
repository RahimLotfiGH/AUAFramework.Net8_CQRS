using System.Threading.Channels;
using AUA.ProjectName.Models.DomainEvents.AuditLog;
using AUA.ProjectName.Models.DomainEvents.Base;

namespace AUA.ProjectName.WebApi.Registrations
{
    public static class DomainEvents
    {
        public static void RegistrationDomainEvents(this IServiceCollection services)
        {

            services.RegistrationDomainEvent();

            services.RegistrationAuditLogDomainEvent();

            services.RegistrationFullAuditLogDomainEvent();

        }

        private static void RegistrationDomainEvent(this IServiceCollection services)
        {
            var bus = Channel.CreateBounded<IDomainEvent>(new BoundedChannelOptions(10)
            {
                FullMode = BoundedChannelFullMode.Wait
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

    }
}
