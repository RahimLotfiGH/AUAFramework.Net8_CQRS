using AUA.Infrastructure.ReportInfra.Handler;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using MediatR;

namespace AUA.ProjectName.Infrastructure.ReportInfra.Handler
{
    public class BaseReportHandler<TReport, TResponse> : BaseReportHandlerInfra<TReport, TResponse>
                              where TReport : IRequest<ResultModel<ListResult<TResponse>>>
    {


        protected void ValidationBaseRequest(BaseSearchFilter searchFilter)
        {
            if (searchFilter.PageSize <= 0)
                AddError("PageSize", " PageSize can not be less than zero or zero");

            if (searchFilter.TotalSize < 0)
                AddError("TotalSize", " TotalSize can not be less than zero ");

            if (searchFilter.PageNumber <= 0)
                AddError("PageNumber", " PageNumber can not be less than zero or zero");

        }

        protected ResultModel<TResultModel> CreateSuccessResult<TResultModel>(TResultModel resultModel)
        {
            return new ResultModel<TResultModel>
            {
                Result = resultModel,
            };
        }
    }
}
