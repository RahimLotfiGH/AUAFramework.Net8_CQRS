using AUA.ProjectName.Commands.Commands.Accounting.AppUserCommands.Update;
using AUA.ProjectName.Commands.Mapping.Accounting;
using AUA.ProjectName.Common.Extensions.ValidationExtensions;
using AUA.ProjectName.Infrastructure.CommandInfra.Handler.Base;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;

namespace AUA.ProjectName.CommandHandler.CommandHandlers.Accounting.AppUserCommandHandlers
{
    public class UpdateAppUserCommandHandler : BaseCommandHandler<UpdateAppUserCommand, bool>
    {
        private readonly IAppUserService _appUserService;

        public UpdateAppUserCommandHandler(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public override void Validation()
        {

            if (_request.FirstName.IsEmpty())
                AddError(UpdateAppUserResultStatus.FirstNameIsEmpty);

            if (_request.LastName.IsEmpty())
                AddError(UpdateAppUserResultStatus.LastNameIsEmpty);

            if (!_request.Phone.IsPhoneNumber())
                AddError(UpdateAppUserResultStatus.InvalidPhoneNumber);

        }

        public override async Task<ResultModel<bool>> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            var appUser = await _appUserService.GetByIdAsync(_request.AppUserId, cancellationToken);

            if (appUser is null)
                return CreateInvalidResult<bool>(UpdateAppUserResultStatus.UserNotFound);

            appUser.SetValues(_request);

            await _appUserService.UpdateAsync(appUser, cancellationToken);

            return CreateSuccessResult(true);
        }



    }
}
