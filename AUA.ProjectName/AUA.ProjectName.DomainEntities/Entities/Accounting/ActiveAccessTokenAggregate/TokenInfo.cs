
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.DomainEntities.Entities.Accounting.ActiveAccessTokenAggregate
{
    [Owned]
    public record TokenInfo
    {
        public DateTime ExpirationDate { get; set; }

        public string RefreshToken { get; set; }

        public string AccessToken { get; set; }

        public bool IsEqualsAccessToken(string accessToken)
        {
            return AccessToken == accessToken;
        }
    }
}
