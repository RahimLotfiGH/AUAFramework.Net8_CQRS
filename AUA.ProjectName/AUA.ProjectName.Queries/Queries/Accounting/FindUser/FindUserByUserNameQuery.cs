using AUA.Infrastructure.QueryInfra.Query;

namespace AUA.ProjectName.Queries.Queries.Accounting.FindUser
{
    public class FindUserByUserNameQuery : BaseQuery<FindUserByUserNameQueryResponse>
    {
        public string? UserName { get; set; }

    }
}
