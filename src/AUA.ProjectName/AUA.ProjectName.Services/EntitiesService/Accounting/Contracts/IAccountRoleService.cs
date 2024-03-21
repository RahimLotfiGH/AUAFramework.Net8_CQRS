using AUA.Infrastructure.BaseServices;
using AUA.ProjectName.DomainEntities.Entities.Accounting.AccountRoleAggregate;

namespace AUA.ProjectName.Services.EntitiesService.Accounting.Contracts
{
    public interface IAccountRoleService : IDomainEntityService<AccountRole>
    {
        Task AddDefaultRoleToAccount(long accountId);
    }
}
