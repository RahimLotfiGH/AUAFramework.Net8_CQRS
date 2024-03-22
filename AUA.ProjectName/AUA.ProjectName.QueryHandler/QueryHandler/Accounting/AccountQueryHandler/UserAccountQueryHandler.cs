using AUA.ProjectName.Infrastructure.QueryInfra.Handler;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Queries.Mapping.Accounting;
using AUA.ProjectName.Queries.Queries.Accounting.UserAccounts;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;

namespace AUA.ProjectName.QueryHandler.QueryHandler.Accounting.AccountQueryHandler
{
    public class UserAccountQueryHandler : BaseQueryHandler<UserAccountQuery, UserAccountQueryResponse>
    {
        private readonly IAccountService _accountService;

        public UserAccountQueryHandler(IAccountService accountService)
        {
            _accountService = accountService;
        }


        public override void Validation()
        {
            //If you need validations
        }

        public override async Task<ResultModel<IEnumerable<UserAccountQueryResponse>>> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            var accounts = await _accountService.GetAccountsByAppUserIdAsync(_request.AppUserId, cancellationToken);

            var contacts = accounts.ToUserAccountQueryResponses();

            return CreateSuccessResult(contacts);

        }
    }
}
