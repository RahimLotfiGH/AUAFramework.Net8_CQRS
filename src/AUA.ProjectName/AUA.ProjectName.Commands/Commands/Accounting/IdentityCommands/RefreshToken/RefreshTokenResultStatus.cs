using System.ComponentModel;

namespace AUA.ProjectName.Commands.Commands.Accounting.IdentityCommands.RefreshToken;

public enum RefreshTokenResultStatus
{
    [Description("Success")]
    Success = 0,

    [Description("Access token is empty")]
    AccessTokenIsEmpty = 1,

    [Description("Invalid access token")]
    InvalidAccessToken = 2,

    [Description("refresh token is empty")]
    RefreshTokenIsEmpty = 2,

    [Description("Invalid refresh token")]
    InvalidRefreshToken = 4,

    [Description("The token refresh time has expired.")]
    RefreshTokenExpired = 5,

    [Description("User is not active.")]
    UserNotActive = 6,

}