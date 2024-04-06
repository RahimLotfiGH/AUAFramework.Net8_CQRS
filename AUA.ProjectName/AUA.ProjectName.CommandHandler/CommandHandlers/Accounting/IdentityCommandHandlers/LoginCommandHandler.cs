using AUA.ProjectName.Commands.Commands.Accounting.IdentityCommands.Login;
using AUA.ProjectName.Common.Extensions.ValidationExtensions;
using AUA.ProjectName.Infrastructure.CommandInfra.Handler.Base;
using AUA.ProjectName.Infrastructure.PipelineBehaviors.Attributes;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Models.DomainEvents.Accounting;
using AUA.ProjectName.Models.DynamicAggregate.Accounting;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ProjectName.Services.GeneralService.Login.Contracts;

namespace AUA.ProjectName.CommandHandler.CommandHandlers.Accounting.IdentityCommandHandlers
{

    [AuditLog]
    public class LoginCommandHandler : BaseCommandHandler<LoginCommand, LoginResponse>
    {
        private readonly IAccessTokenService _accessTokenService;
        private readonly IAccountService _accountService;
        private readonly IClientService _clientService;
        private AccountLoginDto _loginDto;

        public LoginCommandHandler(IAccessTokenService accessTokenService
                                   , IAccountService accountService
                                   , IClientService clientService)
        {
            _accessTokenService = accessTokenService;
            _accountService = accountService;
            _clientService = clientService;
        }

        public override void Validation()
        {
            if (_request.Password.IsEmpty())
                AddError(LoginResultStatus.UserNameOrPasswordIsNull);

            if (_request.UserName.IsEmpty())
                AddError(LoginResultStatus.UserNameOrPasswordIsNull);

            if (_request.ClientId.IsEmpty())
                AddError(LoginResultStatus.ClientId);

        }

        protected override async Task FixValuesAsync(CancellationToken cancellationToken = default)
        {
            if (_request.ClientId is null)
                await SetDefaultClientIdAsync();
        }

        private async Task SetDefaultClientIdAsync()
        {
            var client = await _clientService.GetIsDefaultClientAsync();

            _request.ClientId = client.ClientIdentity;
        }


        public override async Task<ResultModel<LoginResponse>> ExecuteAsync(CancellationToken cancellationToken)
        {
            _loginDto = await _accountService.GetAccountLoginDtoByUserNameAsync(_request.UserName);

            if (_loginDto is null)
                return CreateInvalidResult<LoginResponse>(LoginResultStatus.InValidUserNameOrPassword);

            if (!_loginDto.PasswordCredential.IsValidatePassword(_request.Password))
                return CreateInvalidResult<LoginResponse>(LoginResultStatus.InValidUserNameOrPassword);

            if (_loginDto.IsActive is false)
                return CreateInvalidResult<LoginResponse>(LoginResultStatus.UserNotActive);

            var loginResult = await _accessTokenService.CreateAccountAccessToken(_loginDto, _request.ClientId!.Value);

            return CreateSuccessResult(loginResult);
        }

        protected override async Task PublishEventAsync()
        {
            var domainEvent = CreateAccountingDomainEvent();

            await WriterEventAsync(domainEvent);
        }

        private LoginDomainEvent CreateAccountingDomainEvent()
        {
            return new LoginDomainEvent
            {
                ExecutorCommandName = CommandName,
                IssueTime = DateTime.UtcNow,
                UserName = _loginDto.UserName,
                UserId = _loginDto.AppUserId,
                ClientIdentity = _request.ClientId,
                AccountId = _loginDto.Id
            };
        }

    }


}
