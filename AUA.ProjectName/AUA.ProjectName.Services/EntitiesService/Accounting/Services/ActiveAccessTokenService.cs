using AUA.Infrastructure.BaseServices;
using AUA.ProjectName.DomainEntities.Entities.Accounting.ActiveAccessTokenAggregate;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.Services.EntitiesService.Accounting.Services
{
    public class ActiveAccessTokenService : DomainEntityService<ActiveAccessToken>, IActiveAccessTokenService
    {

        public async Task<ActiveAccessToken> GetActiveAccessTokenByRefreshToken(string refreshToken)
        {
            return await GetAll().FirstOrDefaultAsync(token => 
                                                      token.TokenInfo.RefreshToken == refreshToken);
        }

        public async Task DeleteAllActiveAccessTokensAsync(long accountId, int clintId)
        {
            var ids = await GetAll().Where(p => p.AccountId == accountId &&
                                                p.ClientId == clintId)
                                         .ToListAsync();

            foreach (var id in ids)
                await DeleteAsync(id.Id);

        }
    }
}
