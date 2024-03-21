using AUA.ProjectName.Models.DomainEvents.AuditLog;
using MediatR;
using System.Threading.Channels;
using AUA.ProjectName.Common.Extensions;

namespace AUA.ProjectName.Infrastructure.PipelineBehaviors.Behaviors
{
    public class FullAuditLogBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : MediatR.IRequest<TResponse>
    {
        private readonly Channel<FullAuditLogDomainEvent> _eventBus;

        public FullAuditLogBehaviour(Channel<FullAuditLogDomainEvent> eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var response = await next();

            await PublishEventAsync(request, response);

            return response;
        }

        private async Task PublishEventAsync(TRequest request, TResponse response)
        {
            var @event = CreateFullAuditLogDomainEvent(request, response);

           await _eventBus.Writer.WriteAsync(@event);
        }

        private static FullAuditLogDomainEvent CreateFullAuditLogDomainEvent(TRequest request, TResponse response)
        {
            return new FullAuditLogDomainEvent
            {
                CommandName = CommandName,
                IssueTime = DateTime.UtcNow,
                Request = request.ClearParameters(),
                Response = response
            };
        }

        private static string CommandName => typeof(TRequest).Name;
    }
}
