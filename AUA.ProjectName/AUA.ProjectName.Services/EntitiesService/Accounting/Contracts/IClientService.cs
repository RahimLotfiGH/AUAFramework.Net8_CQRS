using AUA.Infrastructure.BaseServices;
using AUA.ProjectName.DomainEntities.Entities.Accounting.ClientAggregate;

namespace AUA.ProjectName.Services.EntitiesService.Accounting.Contracts
{
    public interface IClientService : IDomainEntityService<Client, int>
    {
        Task<Client> GetClientByClientIdentityAsync(Guid clientIdentity);

        Task<Client> GetIsDefaultClientAsync();
    }
}
