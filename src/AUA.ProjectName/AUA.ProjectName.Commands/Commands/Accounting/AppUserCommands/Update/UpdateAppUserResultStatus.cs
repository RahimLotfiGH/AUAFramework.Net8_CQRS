using System.ComponentModel;

namespace AUA.ProjectName.Commands.Commands.Accounting.AppUserCommands.Update;

public enum UpdateAppUserResultStatus
{
    [Description("Success")]
    Success = 0,

    [Description("FirstName is empty")]
    FirstNameIsEmpty = 3,

    [Description("LastName is empty")]
    LastNameIsEmpty = 4,

    [Description("Invalid phone number")]
    InvalidPhoneNumber = 5,

    [Description("User not found")]
    UserNotFound = 6,

}