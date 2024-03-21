using AUA.Infrastructure.BaseServices;
using AUA.ProjectName.DomainEntities.Entities.Accounting.ClientAggregate;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.Services.EntitiesService.Accounting.Services
{
    public class ClientService : DomainEntityService<Client, int>, IClientService
    {

        public async Task<Client> GetClientByClientIdentityAsync(Guid clientIdentity)
        {
            return await GetAll().FirstOrDefaultAsync(client =>
                                                            client.ClientIdentity == clientIdentity);
        }

        public async Task<Client> GetIsDefaultClientAsync()
        {
            return await GetAll().FirstOrDefaultAsync(client => client.IsDefault);
        }
    }
}
