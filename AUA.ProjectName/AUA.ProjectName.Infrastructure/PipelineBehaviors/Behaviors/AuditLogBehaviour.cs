using System.Threading.Channels;
using AUA.ProjectName.Common.Extensions;
using AUA.ProjectName.Models.DomainEvents.AuditLog;
using MediatR;

namespace AUA.Infrastructure.PipelineBehaviors.Behaviors
{
    public class AuditLogBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : MediatR.IRequest<TResponse>
    {
        private readonly Channel<AuditLogDomainEvent> _eventBus;

        public AuditLogBehaviour(Channel<AuditLogDomainEvent> eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var response = await next();

            await PublishEventAsync(request);

            return response;
        }

        private async Task PublishEventAsync(TRequest request)
        {
            var @event = CreateFullAuditLogDomainEvent(request);

           await _eventBus.Writer.WriteAsync(@event);
        }

        private static AuditLogDomainEvent CreateFullAuditLogDomainEvent(TRequest request)
        {
            return new AuditLogDomainEvent
            {
                CommandName = CommandName,
                IssueTime = DateTime.UtcNow,
                Request = request.ClearParameters(),
            };
        }

        private static string CommandName => typeof(TRequest).Name;
    }
}
