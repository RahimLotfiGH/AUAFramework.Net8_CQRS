using AUA.Infrastructure.BaseServices;
using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.DomainEntities.Entities.Accounting.AccountRoleAggregate;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;

namespace AUA.ProjectName.Services.EntitiesService.Accounting.Services
{
    public class AccountRoleService : DomainEntityService<AccountRole>, IAccountRoleService
    {

        public async Task AddDefaultRoleToAccount(long accountId)
        {
            var accountRole = CreateDefaultAccountRole(accountId);

            await InsertAsync(accountRole);
        }

        private static AccountRole CreateDefaultAccountRole(long accountId)
        {
            return new AccountRole
            {
                RoleId = DefaultValueConsts.DefaultRoleId,
                UserAccountId = accountId
            };
        }

    }
}
