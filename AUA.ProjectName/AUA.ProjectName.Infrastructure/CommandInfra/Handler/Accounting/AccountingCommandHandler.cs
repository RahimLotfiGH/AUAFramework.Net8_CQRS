using System.Threading.Channels;
using AUA.Infrastructure.Utilities.ServiceUtilities;
using AUA.ProjectName.Infrastructure.CommandInfra.Handler.Base;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Models.DomainEvents.Accounting;
using AUA.ProjectName.Models.DomainEvents.AppUsers;
using MediatR;

namespace AUA.ProjectName.Infrastructure.CommandInfra.Handler.Accounting
{
    public class AccountingCommandHandler<TCommand, TResponse>: BaseCommandHandler<TCommand, TResponse> where TCommand : IRequest<ResultModel<TResponse>>
    {
        private readonly Channel<LoginDomainEvent> _loginDomainEventBus;
        private readonly Channel<CreatedAppUserDomainEvent> _createdAppUserDomainEventBus;
        private readonly Channel<CreatedAccountDomainEvent> _createdAccountDomainEventBus;
        

        protected AccountingCommandHandler()
        {
            _createdAccountDomainEventBus = AppServiceFactory.GetService<Channel<CreatedAccountDomainEvent>>(); ;
            _loginDomainEventBus = AppServiceFactory.GetService<Channel<LoginDomainEvent>>();
            _createdAppUserDomainEventBus = AppServiceFactory.GetService<Channel<CreatedAppUserDomainEvent>>();
        }
        
        protected async Task WriterEventAsync(LoginDomainEvent message)
        {
            await _loginDomainEventBus.Writer
                                      .WriteAsync(message);
        }

        protected async Task WriterEventAsync(CreatedAppUserDomainEvent message)
        {
            await _createdAppUserDomainEventBus.Writer
                                               .WriteAsync(message);
        }

        protected async Task WriterEventAsync(CreatedAccountDomainEvent message)
        {
            await _createdAccountDomainEventBus.Writer
                                               .WriteAsync(message);
        }
    }
}
