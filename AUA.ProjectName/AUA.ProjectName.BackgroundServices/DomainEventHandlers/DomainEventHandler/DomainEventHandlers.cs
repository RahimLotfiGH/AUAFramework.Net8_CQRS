using System.Threading.Channels;
using AUA.ProjectName.Models.DomainEvents.Base;
using Microsoft.Extensions.Hosting;

namespace AUA.ProjectName.BackgroundServices.DomainEventHandlers.DomainEventHandler
{
    public class DomainEventHandlers : BackgroundService
    {
        private readonly Channel<IDomainEvent> _eventBus;

        public DomainEventHandlers(Channel<IDomainEvent> bus)
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

            }
        }
    }
}
