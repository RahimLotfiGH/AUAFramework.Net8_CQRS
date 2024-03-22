using AUA.ProjectName.Common.Extensions;
using AUA.ProjectName.DomainEntities.Entities.Accounting.UserAccessAggregate;
using Microsoft.AspNetCore.Authorization;

namespace AUA.ProjectName.WebApi.Utility.ApiAuthorization
{
    public class WebApiAuthorizeAttribute : AuthorizeAttribute
    {
        public WebApiAuthorizeAttribute(params EUserAccess[] userAccesses)
        {
            Roles = userAccesses != null && userAccesses.Any() ?
                    string.Join(",", userAccesses.Select(p => p.GetId())) :
                    null;
        }
    }

}
