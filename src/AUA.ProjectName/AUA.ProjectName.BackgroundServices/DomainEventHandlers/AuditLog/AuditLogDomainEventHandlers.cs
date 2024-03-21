using System.Threading.Channels;
using AUA.ProjectName.Models.DomainEvents.AuditLog;
using Microsoft.Extensions.Hosting;

namespace AUA.ProjectName.BackgroundServices.DomainEventHandlers.AuditLog
{
    public class AuditLogDomainEventHandlers : BackgroundService
    {
        private readonly Channel<AuditLogDomainEvent> _eventBus;

        public AuditLogDomainEventHandlers(Channel<AuditLogDomainEvent> bus)
        {
            _eventBus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await ProcessEventAsync(stoppingToken);

            }
        }

        private async Task ProcessEventAsync(CancellationToken stoppingToken)
        {
            await foreach (var @event in _eventBus.Reader.ReadAllAsync(stoppingToken))
            {
                //ToDo:Log all request
            }
        }

      
    }
}
