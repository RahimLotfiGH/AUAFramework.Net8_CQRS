using AUA.Infrastructure.BaseServices;
using AUA.Mapping.Mapping;
using AUA.ProjectName.DomainEntities.Entities.Accounting.AccountAggregate;
using AUA.ProjectName.Models.DynamicAggregate.Accounting;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.Services.EntitiesService.Accounting.Services
{
    public class AccountService : DomainEntityService<Account>, IAccountService
    {

        public async Task<AccountLoginDto> GetAccountLoginDtoByUserNameAsync(string userName)
        {
            return await GetAll().AsNoTracking()
                                 .Where(account => account.UserName == userName)
                                 .ConvertTo<AccountLoginDto>(MapperInstance)
                                 .FirstOrDefaultAsync();
        }


        public async Task<AccountLoginDto> GetAccountLoginDtoByAccountIdAsync(long accountId)
        {
            return await GetAll().AsNoTracking()
                                 .Where(account => account.Id == accountId)
                                 .ConvertTo<AccountLoginDto>(MapperInstance)
                                 .FirstOrDefaultAsync();
        }

        public async Task<bool> IsExistUserNameAsync(string userName)
        {
            return await GetAll().AsNoTracking()
                                 .AnyAsync(p => p.UserName == userName);
        }


        public async Task<IEnumerable<Account>> GetAccountsByAppUserIdAsync(long appUserId, CancellationToken cancellationToken)
        {
            return await GetAll().AsNoTracking()
                                 .Where(account => account.AppUserId == appUserId)
                                 .ToListAsync(cancellationToken);
        }
    }
}
