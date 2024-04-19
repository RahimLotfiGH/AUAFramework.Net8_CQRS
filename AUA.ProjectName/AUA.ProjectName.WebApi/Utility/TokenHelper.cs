using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.WebApi.Utility.Extensions;

namespace AUA.ProjectName.WebApi.Utility
{
    public static class TokenHelper
    {

        public static long GetUserId(this HttpContext context)
        {
            var userId = context.User
                          .Identity!.GetUserId();

            return string.IsNullOrWhiteSpace(userId) ?
                   DefaultValueConsts.SystemUserId : long.Parse(userId);
        }

        public static long GetAccountId(this HttpContext context)
        {
            var accountId = context.User
                                   .Identity!.GetAccountId();

            return long.Parse(accountId);
        }

        public static int GetClientId(this HttpContext context)
        {
            var clientId = context.User
                                  .Identity!.GetClientId();

            return int.Parse(clientId);
        }
    }
}
