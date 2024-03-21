using System.Threading.Channels;
using AUA.ProjectName.Models.DomainEvents.General;
using Microsoft.Extensions.Hosting;

namespace AUA.ProjectName.BackgroundServices.DomainEventHandlers.General
{
    public class ActionDomainEventHandlers : BackgroundService
    {
        private readonly Channel<ActionDomainEvent> _eventBus;

        public ActionDomainEventHandlers(Channel<ActionDomainEvent> bus)
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
                //ToDo:Log all command called
            }
        }
    }
}
