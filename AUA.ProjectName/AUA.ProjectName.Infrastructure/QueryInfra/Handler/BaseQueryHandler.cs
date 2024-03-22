using AUA.Infrastructure.QueryInfra.Handler;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using MediatR;

namespace AUA.ProjectName.Infrastructure.QueryInfra.Handler
{
    public class BaseQueryHandler<TQuery, TResponse> : BaseQueryHandlerInfra<TQuery, TResponse> where TQuery : IRequest<ResultModel<IEnumerable<TResponse>>>
    {


      
        protected static ResultModel<IEnumerable<TResultModel>> CreateSuccessResult<TResultModel>(TResultModel resultModel)
        {
            return new ResultModel< IEnumerable < TResultModel >>
            {
                Result = new List<TResultModel>
                {
                    resultModel
                }
            };
        }


        protected static ResultModel<IEnumerable<TResultModel>> CreateSuccessResult<TResultModel>(IEnumerable<TResultModel> resultModel)
        {
            return new ResultModel<IEnumerable<TResultModel>>
            {
                Result = resultModel,
            };
        }
    }
}
