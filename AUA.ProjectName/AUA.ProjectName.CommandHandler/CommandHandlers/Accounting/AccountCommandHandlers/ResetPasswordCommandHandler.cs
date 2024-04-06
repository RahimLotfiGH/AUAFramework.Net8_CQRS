using AUA.ProjectName.Commands.Commands.Accounting.Account.ResetPassword;
using AUA.ProjectName.Common.Tools.Config.JsonSetting;
using AUA.ProjectName.DomainEntities.Entities.Accounting.AccountAggregate;
using AUA.ProjectName.Infrastructure.CommandInfra.Handler.Base;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;

namespace AUA.ProjectName.CommandHandler.CommandHandlers.Accounting.AccountCommandHandlers
{
    public class ResetPasswordCommandHandler : BaseCommandHandler<ResetPasswordCommand, bool>
    {
        private readonly IAccountService _accountService;

        public ResetPasswordCommandHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public override void Validation()
        {
        }

        public override async Task<ResultModel<bool>> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            var account = await _accountService.GetByIdAsync(_request.AccountId, cancellationToken);

            if (account is null)
                return CreateInvalidResult<bool>(ResetPasswordResultStatus.AccountNotFound);

            account.PasswordCredential = new PasswordCredential(AppSetting.DefaultPassword);

            await _accountService.UpdateAsync(account, cancellationToken);

            return CreateSuccessResult(true);
        }



    }
}
