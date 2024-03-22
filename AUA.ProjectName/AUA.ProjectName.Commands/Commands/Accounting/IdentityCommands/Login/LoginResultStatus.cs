using System.ComponentModel;

namespace AUA.ProjectName.Commands.Commands.Accounting.IdentityCommands.Login;

public enum LoginResultStatus
{
    [Description("Success")]
    Success = 0,

    [Description("UserName Or Password Is Null")]
    UserNameOrPasswordIsNull = 1,

    [Description("Username or password is incorrect.")]
    InValidUserNameOrPassword = 2,

    [Description("User is not active.")]
    UserNotActive = 3,

    [Description("Client Id is empty.")]
    ClientId = 4,

}