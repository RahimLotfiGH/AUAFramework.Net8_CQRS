using AUA.Infrastructure.BaseServices;
using AUA.ProjectName.DomainEntities.Entities.Accounting.AccountAggregate;
using AUA.ProjectName.Models.DynamicAggregate.Accounting;

namespace AUA.ProjectName.Services.EntitiesService.Accounting.Contracts
{
    public interface IAccountService : IDomainEntityService<Account>
    {
        Task<AccountLoginDto> GetAccountLoginDtoByUserNameAsync(string userName);

        Task<AccountLoginDto> GetAccountLoginDtoByAccountIdAsync(long accountId);

        Task<bool> IsExistUserNameAsync(string userName);

        Task<IEnumerable<Account>> GetAccountsByAppUserIdAsync(long appUserId, CancellationToken cancellationToken);
    }
}
