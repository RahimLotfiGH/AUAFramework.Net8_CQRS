using System.ComponentModel;

namespace AUA.ProjectName.Reports.Reports.UserReports;

public enum UserReportResultReason
{
    [Description("Success")]
    Success = 0,

    [Description("Username should be more then 3 char")]
    UsernameShouldBeMoreThen3Char = 1,

    [Description("FirstName should be more then 3 char")]
    FirstNameShouldBeMoreThen3Char = 2,

    [Description("LastName should be more then 3 char")]
    LastNameShouldBeMoreThen3Char = 3,
}