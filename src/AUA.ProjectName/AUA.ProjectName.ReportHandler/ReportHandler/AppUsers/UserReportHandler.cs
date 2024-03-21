using AUA.ProjectName.Infrastructure.ReportInfra.Handler;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Reports.Reports.UserReports;
using AUA.ProjectName.Services.ReportService.Accounting.Contracts;

namespace AUA.ProjectName.ReportHandler.ReportHandler.AppUsers
{
    public class UserReportHandler : BaseReportHandler<UserReport, UserReportResponse>
    {

        private readonly IUserReportService _appUserListService;

        public UserReportHandler(IUserReportService appUserListService)
        {
            _appUserListService = appUserListService;
        }

        public override void Validation()
        {
            ValidationBaseRequest(_request);

            if (_request.UserName?.Length < 3)
                AddError(UserReportResultReason.UsernameShouldBeMoreThen3Char);

            if (_request.FirstName?.Length < 3)
                AddError(UserReportResultReason.FirstNameShouldBeMoreThen3Char);

            if (_request.LastName?.Length < 3)
                AddError(UserReportResultReason.LastNameShouldBeMoreThen3Char);

        }

        public override void FixValues()
        {
            //In arabic and persian char 
            // if (_request.UserName is not null)
            //    _request.UserName = _request.UserName.FixFarsiChars();
        }

        public override async Task<ResultModel<ListResult<UserReportResponse>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var result = await _appUserListService.ListAsync(_request);


            return CreateSuccessResult(result);
        }


    }
}
