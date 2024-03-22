using AUA.Mapping.Mapping;
using AUA.ProjectName.Infrastructure.QueryInfra.Handler;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Queries.Queries.Accounting.FindUser;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using Microsoft.EntityFrameworkCore;


namespace AUA.ProjectName.QueryHandler.QueryHandler.Accounting.AppUserQueryHandler
{
    public class FindUserByUserNameQueryHandler : BaseQueryHandler<FindUserByUserNameQuery, FindUserByUserNameQueryResponse>
    {
        private readonly IAppUserService _appUserService;

        public FindUserByUserNameQueryHandler(IAppUserService appUserService)
        {
            _appUserService = appUserService;

        }

        public override void Validation()
        {
            if (string.IsNullOrEmpty(_request.UserName))
                AddError(FindUserResultReason.UserNameIsNull);

            if (_request.UserName?.Length < 3)
                AddError(FindUserResultReason.UsernameShouldBeMoreThen3Char);

        }

        public override async Task<ResultModel<IEnumerable<FindUserByUserNameQueryResponse>>> ExecuteAsync(CancellationToken cancellationToken = default)
        {

            var result = await _appUserService.GetAll()
                                              .AsNoTracking()
                                              .ConvertTo<FindUserByUserNameQueryResponse>(MapperInstance)
                                              .FirstOrDefaultAsync(appUser => appUser.UserNames.Any(userName => userName == _request.UserName), cancellationToken: cancellationToken);


            return CreateSuccessResult(result!);
        }

    }
}
