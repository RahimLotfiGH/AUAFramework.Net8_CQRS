using System.Threading.Channels;
using AUA.ProjectName.Models.DomainEvents.Accounting;
using Microsoft.Extensions.Hosting;

namespace AUA.ProjectName.BackgroundServices.DomainEventHandlers.Accounting
{
    public class AccountingDomainEventHandlers : BackgroundService
    {
        private readonly Channel<LoginDomainEvent> _eventBus;

        public AccountingDomainEventHandlers(Channel<LoginDomainEvent> bus)
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
