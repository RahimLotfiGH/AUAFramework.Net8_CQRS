using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.WebApi.Utility;
using Microsoft.AspNetCore.Mvc;

namespace AUA.ProjectName.WebApi.Controllers
{
    [Route(AreasConsts.ApiRoute)]
    [ApiController]
    public class InfraApiController : ControllerBase
    {
        protected ValidationResultVm ValidationResultVm;

        protected InfraApiController()
        {
            ValidationResultVm ??= new ValidationResultVm();
        }
    
        protected JsonResult CreateResult(object data)
        {
            return new(data);
        }

        protected void AddError(string errorIssuer, string message)
        {
            ValidationResultVm.ErrorVms.Add(new ErrorVm
            {
                ErrorMessage = message,
                ErrorIssuer = errorIssuer
            });
        }

        protected void AddError(string message)
        {
            AddError(string.Empty, message);
            Log(message);
        }

        protected static ResultModel<TResultModel> CreateSuccessResult<TResultModel>(TResultModel resultModel)
        {
            return new ResultModel<TResultModel>
            {
                Result = resultModel,
            };
        }

        protected void Log(string message)
        {
            //ToDo:
        }

        protected long UserId => HttpContext.GetUserId();

        protected int ClientId => HttpContext.GetClientId();

    }
}
