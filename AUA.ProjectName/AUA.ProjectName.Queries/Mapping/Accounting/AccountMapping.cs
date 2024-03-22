using AUA.ProjectName.DomainEntities.Entities.Accounting.AccountAggregate;
using AUA.ProjectName.Queries.Queries.Accounting.UserAccounts;

namespace AUA.ProjectName.Queries.Mapping.Accounting
{
    public static class AccountMapping
    {
        public static IEnumerable<UserAccountQueryResponse> ToUserAccountQueryResponses(this IEnumerable<Account> accounts)
        {
            return accounts.Select(account => account.ToUserAccountQueryResponse()).ToList();
        }

        private static UserAccountQueryResponse ToUserAccountQueryResponse(this Account account)
        {
            return new UserAccountQueryResponse
            {
                UserName = account.UserName
            };
        }
    }
}
