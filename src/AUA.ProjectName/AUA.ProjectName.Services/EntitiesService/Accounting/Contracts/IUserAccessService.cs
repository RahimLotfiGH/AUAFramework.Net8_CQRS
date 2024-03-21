using AUA.Infrastructure.BaseServices;
using AUA.ProjectName.DomainEntities.Entities.Accounting.UserAccessAggregate;

namespace AUA.ProjectName.Services.EntitiesService.Accounting.Contracts
{
    public interface IUserAccessService : IDomainEntityService<UserAccess,int>
    {
    }
}
