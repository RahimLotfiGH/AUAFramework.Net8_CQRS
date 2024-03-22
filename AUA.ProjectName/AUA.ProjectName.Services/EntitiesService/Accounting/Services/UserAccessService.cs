using AUA.Infrastructure.BaseServices;
using AUA.ProjectName.DomainEntities.Entities.Accounting.UserAccessAggregate;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;

namespace AUA.ProjectName.Services.EntitiesService.Accounting.Services
{
    public class UserAccessService : DomainEntityService<UserAccess,int>, IUserAccessService
    {
     
    }
}
