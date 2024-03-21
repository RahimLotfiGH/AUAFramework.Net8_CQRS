using AUA.Infrastructure.CommandInfra.Handler;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Common.Extensions;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using MediatR;

namespace AUA.ProjectName.Infrastructure.CommandInfra.Handler.Base;

public class BaseCommandHandler<TCommand, TResponse> : BaseCommandHandlerInfra<TCommand, TResponse> where TCommand
    : IRequest<ResultModel<TResponse>>
{

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