using AUA.Infrastructure.BaseServices;
using AUA.ProjectName.DomainEntities.Entities.Accounting.ActiveAccessTokenAggregate;

namespace AUA.ProjectName.Services.EntitiesService.Accounting.Contracts
{
    public interface IActiveAccessTokenService : IDomainEntityService<ActiveAccessToken>
    {
        Task<ActiveAccessToken> GetActiveAccessTokenByRefreshToken(string refreshToken);
        Task DeleteAllActiveAccessTokensAsync(long accountId, int clintId);

    }
}
