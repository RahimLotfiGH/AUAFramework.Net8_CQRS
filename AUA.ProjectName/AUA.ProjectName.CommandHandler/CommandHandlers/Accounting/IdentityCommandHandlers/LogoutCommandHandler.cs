using AUA.ProjectName.Commands.Commands.Accounting.IdentityCommands.Logout;
using AUA.ProjectName.Infrastructure.CommandInfra.Handler.Base;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Services.GeneralService.Login.Contracts;

namespace AUA.ProjectName.CommandHandler.CommandHandlers.Accounting.IdentityCommandHandlers
{
    public class LogoutCommandHandler : BaseCommandHandler<LogoutCommand, bool>
    {
        private readonly IAccessTokenService _accessTokenService;

        public LogoutCommandHandler(IAccessTokenService accessTokenService)
        {
            _accessTokenService = accessTokenService;
        }

        public override async Task<ResultModel<bool>> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            await _accessTokenService.DeleteActiveAccessTokenAsync(_request.UserId, _request.ClientId);

            return CreateSuccessResult(true);
        }


    }
}
