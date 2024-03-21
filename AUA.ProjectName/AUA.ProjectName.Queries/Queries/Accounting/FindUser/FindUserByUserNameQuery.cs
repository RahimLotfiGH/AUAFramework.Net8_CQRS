using AUA.Infrastructure.QueryInfra.Query;
using AUA.ServiceInfrastructure.QueryInfra.Query;

namespace AUA.ProjectName.Queries.Queries.Accounting.FindUser
{
    public class FindUserByUserNameQuery : BaseQuery<FindUserByUserNameQueryResponse>
    {
        public string? UserName { get; set; }

    }
}
