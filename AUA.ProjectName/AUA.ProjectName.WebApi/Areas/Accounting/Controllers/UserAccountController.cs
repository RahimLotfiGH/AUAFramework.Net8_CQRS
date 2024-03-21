using AUA.ProjectName.Commands.Commands.Accounting.Account.ResetPassword;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.Entities.Accounting.UserAccessAggregate;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Queries.Queries.Accounting.UserAccounts;
using AUA.ProjectName.WebApi.Controllers;
using AUA.ProjectName.WebApi.Utility.ApiAuthorization;
using Microsoft.AspNetCore.Mvc;

namespace AUA.ProjectName.WebApi.Areas.Accounting.Controllers
{

    [WebApiAuthorize(EUserAccess.Account)]
    [ApiVersion(ApiVersionConsts.V1)]
    public class UserAccountController : BaseApiController
    {

        [HttpGet]
        public async Task<ResultModel<IEnumerable<UserAccountQueryResponse>>> GetUserAccounts(long appUserId)
        {
            var request = new UserAccountQuery
            {
                AppUserId = appUserId
            };

            return await RequestDispatcher.Send(request);
        }



        [HttpPost]
        [WebApiAuthorize(EUserAccess.ResetPassword)]
        public async Task<ResultModel<bool>> ResetPasswordAsync(long accountId)
        {
            var request = new ResetPasswordCommand
            {
                AccountId = accountId
            };

            return await RequestDispatcher.Send(request);
        }
    }
}
