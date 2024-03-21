using AUA.ProjectName.Common.Consts;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Common.Extensions;
using AUA.ProjectName.Common.Tools.Security;
using AUA.ProjectName.Models.BaseModel.BaseValidationModels;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Models.GeneralModels.AccessTokenModels;
using AUA.ProjectName.Models.GeneralModels.GeneralVm;
using Microsoft.AspNetCore.Mvc;
using static System.String;

namespace AUA.ProjectName.WebApi.Utility
{
    public static class ApplicationHelper
    {

        public static AccessTokenData GetCurrentUserDataVm(HttpContext context)
        {
            var guidAccessToken = GetAuthorizationToken(context);

            if (IsNullOrWhiteSpace(guidAccessToken))
                return new AccessTokenData();

            var jsonAccessToken = EncryptionHelper.AesDecryptString(guidAccessToken);

            if (IsNullOrEmpty(jsonAccessToken))
                return new AccessTokenData();

            var accessTokenDataVm = jsonAccessToken.ObjectDeserialize<AccessTokenData>();

            return accessTokenDataVm;
        }

        public static string GetAuthorizationToken(HttpContext context)
        {
            context
                .Request
                .Headers
                .TryGetValue(AppConsts.AuthorizationAccessTokenName, out var accessToken);

            return IsNullOrWhiteSpace(accessToken.ToString()) ?
                    Empty :
                    accessToken!;
        }

      
    }
}
