using AUA.Infrastructure.QueryInfra.Query;
using AUA.ServiceInfrastructure.QueryInfra.Query;

namespace AUA.ProjectName.Queries.Queries.Accounting.UserAccounts
{
    public class UserAccountQuery : BaseQuery<UserAccountQueryResponse>
    {
        public long AppUserId { get; set; }

    }
}
