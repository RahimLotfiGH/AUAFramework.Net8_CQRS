using System.Text;
using AUA.Infrastructure.Utilities.ServiceUtilities;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using MediatR;

namespace AUA.ProjectName.WebApi.Controllers
{
    public class BaseApiController : InfraApiController
    {
        protected readonly IMediator RequestDispatcher;

        public BaseApiController()
        {
            RequestDispatcher = AppServiceFactory.GetService<IMediator>();
        }


        protected void ValidationSearchVm(BaseSearchFilter searchVm)
        {
            if (searchVm.PageSize <= 0)
                AddError("PageSize", " PageSize can not be less than zero or zero");

            if (searchVm.TotalSize < 0)
                AddError("TotalSize", " TotalSize can not be less than zero ");

            if (searchVm.PageNumber <= 0)
                AddError("PageNumber", " PageNumber can not be less than zero or zero");


        }

        protected void SetAuditInfo<T>(BaseVm<T> baseVm)
        {
            baseVm.CreatorUserId = UserId;
        }


        protected string CreateLogMessage(params string[] messages)
        {
            var logMessage = new StringBuilder();

            foreach (var message in messages)
                logMessage.Append(message + AppConsts.LogSplitter);

            return logMessage.ToString();
        }
    }
}
