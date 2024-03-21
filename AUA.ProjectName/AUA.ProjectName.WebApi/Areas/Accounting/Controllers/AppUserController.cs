using AUA.ProjectName.Commands.Commands.Accounting.AppUserCommands.Insert;
using AUA.ProjectName.Commands.Commands.Accounting.AppUserCommands.Update;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.Entities.Accounting.UserAccessAggregate;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Queries.Queries.Accounting.FindUser;
using AUA.ProjectName.Queries.Queries.Accounting.UserContacts;
using AUA.ProjectName.Reports.Reports.UserReports;
using AUA.ProjectName.WebApi.Controllers;
using AUA.ProjectName.WebApi.Utility.ApiAuthorization;
using Microsoft.AspNetCore.Mvc;

namespace AUA.ProjectName.WebApi.Areas.Accounting.Controllers;


[WebApiAuthorize(EUserAccess.AppUser)]
[ApiVersion(ApiVersionConsts.V1)]
public class AppUserController : BaseApiController
{

    [HttpPost]
    public async Task<ResultModel<long>> InsertAsync(InsertAppUserCommand command)
    {
        return await RequestDispatcher.Send(command);
    }

    [HttpPost]
    public async Task<ResultModel<bool>> UpdateAsync(UpdateAppUserCommand command)
    {
        return await RequestDispatcher.Send(command);
    }

    [HttpGet]
    public async Task<ResultModel<IEnumerable<UserContactQueryResponse>>> GetUserContacts(long appUserId)
    {
        var request = new UserContactQuery
        {
            AppUserId = appUserId
        };

        return await RequestDispatcher.Send(request);
    }


    [HttpGet]
    public async Task<ResultModel<IEnumerable<FindUserByUserNameQueryResponse>>> FindUserByUserNameQueryAsync(string userName)
    {
        var userQuery = new FindUserByUserNameQuery
        {
            UserName = userName
        };

        var result = await RequestDispatcher.Send(userQuery);
        return result;
    }

    //We used the httpPost verb for reports, due to the request length limitations in httpGet.
    //The report filter model will grow in the future(based on experience).
    //You can decide based on your project.

    [HttpPost]
    public async Task<ResultModel<ListResult<UserReportResponse>>> UserReportAsync(UserReport query)
    {
        var result = await RequestDispatcher.Send(query);

        return result;
    }


}