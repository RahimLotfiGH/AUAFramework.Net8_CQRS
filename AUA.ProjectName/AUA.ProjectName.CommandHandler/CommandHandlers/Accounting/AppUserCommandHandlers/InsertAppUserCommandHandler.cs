using AUA.ProjectName.Commands.Commands.Accounting.AppUserCommands.Insert;
using AUA.ProjectName.Commands.Mapping.Accounting;
using AUA.ProjectName.Common.Extensions.ValidationExtensions;
using AUA.ProjectName.Infrastructure.CommandInfra.Handler.Base;
using AUA.ProjectName.Infrastructure.PipelineBehaviors.Attributes;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Models.DomainEvents.Accounting;
using AUA.ProjectName.Models.DomainEvents.AppUsers;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;

namespace AUA.ProjectName.CommandHandler.CommandHandlers.Accounting.AppUserCommandHandlers
{
    [Transaction]
    public class InsertAppUserCommandHandler : BaseCommandHandler<InsertAppUserCommand, long>
    {
        private readonly IAppUserService _appUserService;
        private readonly IAccountService _accountService;
        private readonly IAccountRoleService _accountRoleService;
        private long _appUserId;
        private long _accountId;

        public InsertAppUserCommandHandler(IAppUserService appUserService
                                           , IAccountService accountService
                                           , IAccountRoleService accountRoleService)
        {
            _appUserService = appUserService;
            _accountService = accountService;
            _accountRoleService = accountRoleService;
        }


        public override async Task ValidationAsync(CancellationToken cancellationToken = default)
        {
            if (_request.Password.IsEmpty())
                AddError(InsertAppUserResultStatus.PasswordIsEmpty);

            if (_request.UserName.IsEmpty())
                AddError(InsertAppUserResultStatus.UserNameIsEmpty);

            if (_request.FirstName.IsEmpty())
                AddError(InsertAppUserResultStatus.UserNameIsEmpty);

            if (_request.FirstName.IsEmpty())
                AddError(InsertAppUserResultStatus.FirstNameIsEmpty);

            if (_request.LastName.IsEmpty())
                AddError(InsertAppUserResultStatus.LastNameIsEmpty);

            if (_request.Phone.IsPhoneNumber())
                AddError(InsertAppUserResultStatus.InvalidPhoneNumber);

            var isExistUserName = await _accountService.IsExistUserNameAsync(_request.UserName);

            if (isExistUserName)
                AddError(InsertAppUserResultStatus.UserNameIsExist);
        }

        public override async Task<ResultModel<long>> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            _appUserId = await InsertAppUserAsync(cancellationToken);

            _accountId = await InsertAccountAsync(_appUserId);

            await _accountRoleService.AddDefaultRoleToAccount(_accountId);

            return CreateSuccessResult(_appUserId);
        }

        private async Task<long> InsertAppUserAsync(CancellationToken cancellationToken)
        {
            var appUser = _request.ToAppUser();

            await _appUserService.InsertAsync(appUser, cancellationToken);

            return appUser.Id;
        }

        private async Task<long> InsertAccountAsync(long appUserId)
        {
            var account = _request.ToAccount(appUserId);

            await _accountService.InsertAsync(account);

            return account.Id;
        }

        protected override async Task PublishEventAsync()
        {
            await PublishCreatedAppUserDomainEventAsync();

            await PublishCreatedAccountDomainEventAsync();

        }

        private async Task PublishCreatedAppUserDomainEventAsync()
        {
            var appUserDomainEvent = CreateAppUserDomainEvent();

            await WriterEventAsync(appUserDomainEvent);
        }

        private CreatedAppUserDomainEvent CreateAppUserDomainEvent()
        {
            return new CreatedAppUserDomainEvent
            {
                UserName = _request.UserName,
                ExecutorCommandName = CommandName,
                AccountId = _accountId,
                UserId = _appUserId,

            };
        }
        private async Task PublishCreatedAccountDomainEventAsync()
        {
            var appUserDomainEvent = CreateAccountDomainEvent();

            await WriterEventAsync(appUserDomainEvent);
        }

        private CreatedAccountDomainEvent CreateAccountDomainEvent()
        {
            return new CreatedAccountDomainEvent
            {
                UserName = _request.UserName,
                ExecutorCommandName = CommandName,
                AccountId = _accountId,
                UserId = _appUserId,

            };
        }


    }
}
