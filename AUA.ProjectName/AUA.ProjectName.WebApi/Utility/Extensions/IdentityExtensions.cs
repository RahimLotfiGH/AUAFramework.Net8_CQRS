using System.Security.Claims;
using System.Security.Principal;
using AUA.ProjectName.Common.Consts;

namespace AUA.ProjectName.WebApi.Utility.Extensions
{
    public static class IdentityExtensions
    {
        public static string FindFirstValue(this IIdentity identity, string claimType)
        {
            var claimsIdentity = identity as ClaimsIdentity;

            return claimsIdentity == null? 
                   string.Empty: 
                   claimsIdentity.FindFirstValue(claimType);
        }

        public static string FindFirstValue(this ClaimsIdentity identity, string claimType)
        {
            var claimClaims = identity.FindFirst(claimType);

            return claimClaims == null ? 
                   string.Empty :
                   identity.FindFirst(claimType)!.Value;

        }

        public static string GetClientId(this IIdentity identity)
        {
            return identity.FindFirstValue(ClaimTypeConsts.ClientId);
        }

        public static string GetAccountId(this IIdentity identity)
        {
            return identity.FindFirstValue(ClaimTypeConsts.AccountId);
        }

        public static string GetUserId(this IIdentity identity)
        {
            return identity.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
