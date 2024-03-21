using System.Threading.Channels;
using AUA.ProjectName.Models.DomainEvents.Accounting;
using Microsoft.Extensions.Hosting;

namespace AUA.ProjectName.BackgroundServices.DomainEventHandlers.Accounting
{
    public class CreatedAccountDomainEventHandlers : BackgroundService
    {
        private readonly Channel<CreatedAccountDomainEvent> _eventBus;

        public CreatedAccountDomainEventHandlers(Channel<CreatedAccountDomainEvent> bus)
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
