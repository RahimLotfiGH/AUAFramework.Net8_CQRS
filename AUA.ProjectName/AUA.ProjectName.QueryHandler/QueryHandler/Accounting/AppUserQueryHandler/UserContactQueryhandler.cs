using AUA.ProjectName.Infrastructure.QueryInfra.Handler;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Queries.Mapping.Accounting;
using AUA.ProjectName.Queries.Queries.Accounting.UserContacts;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;

namespace AUA.ProjectName.QueryHandler.QueryHandler.Accounting.AppUserQueryHandler
{
    public class UserContactQueryHandler : BaseQueryHandler<UserContactQuery, UserContactQueryResponse>
    {
        private readonly IAppUserService _appUserService;

        public UserContactQueryHandler(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public override void Validation()
        {
            //If you need validations
        }


        public override async Task<ResultModel<IEnumerable<UserContactQueryResponse>>> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            var appUser = await _appUserService.GetByIdAsync(_request.AppUserId, cancellationToken);

            var contacts = appUser.UserContact.ToUserContactQueryResponse();

            return CreateSuccessResult(contacts);

        }
    }
}
