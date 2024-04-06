using System.Threading.Channels;
using AUA.Infrastructure.CommandInfra.Handler;
using AUA.Infrastructure.Utilities.ServiceUtilities;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Common.Extensions;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Models.DomainEvents.Base;
using MediatR;

namespace AUA.ProjectName.Infrastructure.CommandInfra.Handler.Base;

public class BaseCommandHandler<TCommand, TResponse> : BaseCommandHandlerInfra<TCommand, TResponse> where TCommand
    : IRequest<ResultModel<TResponse>>
{
    private readonly Channel<IDomainEvent> _eventBus;

    protected BaseCommandHandler()
    {
        _eventBus = AppServiceFactory.GetService<Channel<IDomainEvent>>();

    }

    protected async Task WriterEventAsync(IDomainEvent message)
    {
        await _eventBus.Writer
            .WriteAsync(message);
    }


    protected ResultModel<TResultModel> CreateInvalidResult<TResultModel>(Enum reason) 
    {
        return new()
        {
            Errors = new List<ErrorVm>
            {
                new()
                {
                    ErrorType = ELogType.Danger,
                    ErrorMessage =  reason.ToDescription(),
                    ErrorIssuer = string.Empty,
                    ErrorCode = reason.GetId()
                }
            }

        };

    }

    protected static ResultModel<TResultModel> CreateSuccessResult<TResultModel>(TResultModel resultModel)
    {
        return new ResultModel<TResultModel>
        {
            Result = resultModel,
        };
    }

   
}