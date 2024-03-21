using System.ComponentModel;

namespace AUA.ProjectName.Commands.Commands.Accounting.Account.ResetPassword;

public enum ResetPasswordResultStatus
{
    [Description("Success")]
    Success = 0,

    [Description("User not found")]
    AccountNotFound = 1,

}