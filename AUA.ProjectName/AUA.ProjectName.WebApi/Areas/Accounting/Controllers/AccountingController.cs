using AUA.ProjectName.Commands.Commands.Accounting.IdentityCommands.Login;
using AUA.ProjectName.Commands.Commands.Accounting.IdentityCommands.Logout;
using AUA.ProjectName.Commands.Commands.Accounting.IdentityCommands.RefreshToken;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Models.GeneralModels.LoginModels;
using AUA.ProjectName.WebApi.Controllers;
using AUA.ProjectName.WebApi.Utility.ActionFilters;
using AUA.ProjectName.WebApi.Utility.ApiAuthorization;
using Microsoft.AspNetCore.Mvc;

namespace AUA.ProjectName.WebApi.Areas.Accounting.Controllers;


[ApiVersion(ApiVersionConsts.V1)]
[AllowAnonymousAuthorize]
public class AccountingController : BaseApiController
{

    [HttpPost]
    [LoggingRequest]
    public async Task<ResultModel<LoginResponse>> LoginAsync([FromForm] LoginCommand loginCommand, CancellationToken cancellationToken)
    {
        var result = await RequestDispatcher.Send(loginCommand, cancellationToken);

        return result;
    }

    [HttpPost]
    public async Task<SwaggerLoginResponse> SwaggerAccessTokenAsync([FromForm] LoginCommand loginCommand)
    {
        var result = await RequestDispatcher.Send(loginCommand);

        if (result.IsSuccess)
            return CreateLoginToken(result.Result);

        throw new Exception(result.Errors.FirstOrDefault()?.ErrorMessage);
    }

    private static SwaggerLoginResponse CreateLoginToken(LoginResponse result)
    {
        return new SwaggerLoginResponse
        {
            Result = new LoginResultDto
            {
                AccessToken = result.AccessToken,
                ExpiresIn = result.ExpiresIn,
                FirstName = result.FirstName,
                LastName = result.LastName,
                RoleIds = result.RoleIds,
                UserName = result.UserName,
                RefreshToken = result.RefreshToken,
                UserAccessIds = result.UserAccessCodes
            }
        };

    }

    [HttpPost]
    public async Task<ResultModel<RefreshTokenResponse>> RefreshTokenAsync([FromForm] RefreshTokenCommand command)
    {
        var result = await RequestDispatcher.Send(command);

        return result;
    }

    [WebApiAuthorize]
    [HttpPost]
    public async Task<ResultModel<bool>> LogoutAsync()
    {
        var command = CreateLogoutCommand();

        await RequestDispatcher.Send(command);

        return CreateSuccessResult(true);
    }

    private LogoutCommand CreateLogoutCommand()
    {
        return new LogoutCommand
        {
            UserId = UserId,
            ClientId = ClientId
        };
    }


}