using System.ComponentModel;

namespace AUA.ProjectName.Queries.Queries.Accounting.FindUser;

public enum FindUserResultReason
{
    [Description("Success")]
    Success = 0,

    [Description("UserName is Null")]
    UserNameIsNull = 1,

    [Description("Username should be more then 3 char")]
    UsernameShouldBeMoreThen3Char = 2,


}