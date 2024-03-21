using System.ComponentModel;

namespace AUA.ProjectName.Commands.Commands.Accounting.AppUserCommands.Insert;

public enum InsertAppUserResultStatus
{
    [Description("Success")]
    Success = 0,

    [Description("UserName is empty")]
    UserNameIsEmpty = 1,

    [Description("Password is empty.")]
    PasswordIsEmpty = 2,

    [Description("FirstName is empty")]
    FirstNameIsEmpty = 3,

    [Description("LastName is empty")]
    LastNameIsEmpty = 4,

    [Description("Invalid phone number")]
    InvalidPhoneNumber = 5,

    [Description("UserName is exists")]
    UserNameIsExist = 6,

}