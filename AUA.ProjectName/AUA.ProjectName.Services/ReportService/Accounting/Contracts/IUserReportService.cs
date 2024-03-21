using AUA.Infrastructure.BaseSearchService;
using AUA.ProjectName.DomainEntities.Entities.Accounting.AppUserAggregate;
using AUA.ProjectName.Reports.Reports.UserReports;

namespace AUA.ProjectName.Services.ReportService.Accounting.Contracts
{
    public interface IUserReportService : IBaseReportService<AppUser, UserReport, UserReportResponse>
    {


    }
}
