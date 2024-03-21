using AUA.Infrastructure.ReportInfra.Report;

namespace AUA.ProjectName.Reports.Reports.UserReports;

public class UserReport : BaseReport<UserReportResponse>
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? UserName { get; set; }

    public bool? IsActive { get; set; }
}
