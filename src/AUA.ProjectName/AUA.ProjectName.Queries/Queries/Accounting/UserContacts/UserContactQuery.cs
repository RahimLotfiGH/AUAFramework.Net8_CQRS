using AUA.Infrastructure.QueryInfra.Query;
using AUA.ServiceInfrastructure.QueryInfra.Query;

namespace AUA.ProjectName.Queries.Queries.Accounting.UserContacts
{
    public class UserContactQuery: BaseQuery<UserContactQueryResponse>
    {
        public long AppUserId { get; set; }

    }
}
