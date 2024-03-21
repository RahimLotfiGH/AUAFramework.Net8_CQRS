using System.Threading.Channels;
using AUA.ProjectName.Models.DomainEvents.AppUsers;
using Microsoft.Extensions.Hosting;

namespace AUA.ProjectName.BackgroundServices.DomainEventHandlers.AppUsers
{
    public class CreatedAppUserDomainEventHandlers : BackgroundService
    {
        private readonly Channel<CreatedAppUserDomainEvent> _eventBus;

        public CreatedAppUserDomainEventHandlers(Channel<CreatedAppUserDomainEvent> bus)
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
