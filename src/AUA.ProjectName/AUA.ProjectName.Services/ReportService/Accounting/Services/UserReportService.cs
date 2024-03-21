using AUA.Infrastructure.BaseSearchService;
using AUA.ProjectName.DomainEntities.Entities.Accounting.AppUserAggregate;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Reports.Reports.UserReports;
using AUA.ProjectName.Services.ReportService.Accounting.Contracts;

namespace AUA.ProjectName.Services.ReportService.Accounting.Services
{
    public sealed class UserReportService : BaseReportService<AppUser, UserReport,UserReportResponse>, IUserReportService
    {

        public async Task<ListResult<UserReportResponse>> ListAsync(UserReport appUserSearchVm)
        {
            SetSearchVm(appUserSearchVm);

            ApplyUserNameFilter();
            ApplyLastNameFilter();
            ApplyFirstNameFilter();
            ApplyIsActiveFilters();


            return await CreateListResultAsync();
        }

        private void ApplyUserNameFilter()
        {
            if (SearchVm.UserName is null)
                return;

            Query = Query.Where(p => p.UserAccounts.Any(account=>account.UserName.Contains(SearchVm.UserName)));
        }

        private void ApplyLastNameFilter()
        {
            if (SearchVm.LastName is null)
                return;

            Query = Query.Where(p => p.LastName.Contains(SearchVm.LastName));
        }

        private void ApplyFirstNameFilter()
        {
            if (SearchVm.FirstName is null)
                return;

            Query = Query.Where(p => p.FirstName.Contains(SearchVm.FirstName));
        }

        private void ApplyIsActiveFilters()
        {
            if (SearchVm.IsActive is null)
                return;

            Query = Query.Where(p => p.IsActive == SearchVm.IsActive);
        }


    }
}
