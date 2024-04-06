using AUA.ProjectName.Commands.Commands.Accounting.IdentityCommands.Login;
using AUA.ProjectName.Commands.Commands.Accounting.IdentityCommands.RefreshToken;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Common.Extensions;
using AUA.ProjectName.Common.Extensions.ValidationExtensions;
using AUA.ProjectName.Common.Tools.Security;
using AUA.ProjectName.DomainEntities.Entities.Accounting.ActiveAccessTokenAggregate;
using AUA.ProjectName.Infrastructure.CommandInfra.Handler.Base;
using AUA.ProjectName.Models.BaseModel.BaseViewModels;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ProjectName.Services.GeneralService.Login.Contracts;

namespace AUA.ProjectName.CommandHandler.CommandHandlers.Accounting.IdentityCommandHandlers
{
    public class RefreshTokenCommandHandler : BaseCommandHandler<RefreshTokenCommand, RefreshTokenResponse>
    {
        private readonly IAccessTokenService _accessTokenService;
        private readonly IActiveAccessTokenService _activeAccessTokenService;
        private readonly IClientService _clientService;
        private readonly IAccountService _accountService;
        private ActiveAccessToken _activeAccessToken;

        public RefreshTokenCommandHandler(IAccessTokenService accessTokenService
                                          , IActiveAccessTokenService activeAccessTokenService
                                          , IAccountService accountService
                                          , IClientService clientService)
        {
            _accessTokenService = accessTokenService;
            _activeAccessTokenService = activeAccessTokenService;
            _accountService = accountService;
            _clientService = clientService;
        }

        public override void Validation()
        {
            if (_request.AccessToken.IsEmpty())
                AddError(RefreshTokenResultStatus.AccessTokenIsEmpty);

            if (_request.RefreshToken.IsEmpty())
                AddError(RefreshTokenResultStatus.RefreshTokenIsEmpty);
        }


        protected override async Task FixValuesAsync(CancellationToken cancellationToken = default)
        {
            if (_request.ClientId is null)
                await SetClientIdAsync();
        }

        private async Task SetClientIdAsync()
        {
            var client = await _clientService.GetIsDefaultClientAsync();

            _request.ClientId = client.ClientIdentity;
        }


        public override async Task<ResultModel<RefreshTokenResponse>> ExecuteAsync(CancellationToken cancellationToken = default)
        {
            _activeAccessToken = await _activeAccessTokenService.GetActiveAccessTokenByRefreshToken(_request.RefreshToken);

            if (_activeAccessToken is null)
                return CreateInvalidResult<RefreshTokenResponse>(RefreshTokenResultStatus.InvalidRefreshToken);

            if (!_activeAccessToken.IsActive)
                return CreateInvalidResult<RefreshTokenResponse>(RefreshTokenResultStatus.InvalidRefreshToken);

            if (!IsValidationAccessToken(_request.AccessToken))
                return CreateInvalidResult<RefreshTokenResponse>(RefreshTokenResultStatus.InvalidAccessToken);

            if (!TokenHelper.IsValidationExpirationDate(_activeAccessToken.TokenInfo.ExpirationDate))
                return CreateInvalidResult<RefreshTokenResponse>(RefreshTokenResultStatus.RefreshTokenExpired);

            var loginDto = await _accountService.GetAccountLoginDtoByAccountIdAsync(_activeAccessToken.AccountId);

            if (loginDto.IsActive is false)
                return CreateInvalidResult<RefreshTokenResponse>(RefreshTokenResultStatus.UserNotActive);


            var loginResult = await _accessTokenService.CreateAccountAccessToken(loginDto, _request.ClientId!.Value);

            return CreateSuccessResult(loginResult);
        }

        private bool IsValidationAccessToken(string accessToken)
        {
            return _activeAccessToken.TokenInfo
                                     .IsEqualsAccessToken(accessToken);
        }

        //protected static ResultModel<TResultModel> CreateSuccessResult<TResultModel>(TResultModel resultModel)
        //{
        //    return new ResultModel<TResultModel>
        //    {
        //        Result = resultModel,
        //    };
        //}

        //private async Task<RefreshTokenResponse> CreateRefreshTokenAsync(long accountId)
        //{




        //    var accessToken = CreateJwtToken(accountId, expirationDate);
        //    var refreshToken = GetGuid();

        //    var clientId = 1;//ToDo: get clientId Form inMemory  services

        //    await _accessTokenService.DeleteActiveAccessTokenAsync(accountId, clientId);

        //    await InsertActiveAccessTokenAsync(accessToken, refreshToken, accountId);


        //    return new RefreshTokenResponse
        //    {
        //        AccessToken = accessToken,
        //        RefreshToken = refreshToken,
        //        ExpiresIn = expirationDate
        //    };
        //}
        //private static string CreateJwtToken(long userId, DateTime expirationDate)
        //{
        //    var jwtDataVm = new AccessTokenDataVm
        //    {
        //        UserId = userId,
        //        ExpirationDate = expirationDate,
        //    };

        //    var jwtDataVmSerialize = jwtDataVm.ObjectSerialize();

        //    return EncryptionHelper.AesEncryptString(jwtDataVmSerialize);
        //}

        protected static ResultModel<RefreshTokenResponse> CreateSuccessResult(LoginResponse resultModel)
        {
            return new ResultModel<RefreshTokenResponse>
            {
                Result = new RefreshTokenResponse
                {
                    AccessToken = resultModel.AccessToken,
                    ExpiresIn = resultModel.ExpiresIn,
                    RefreshToken = resultModel.RefreshToken,
                    AccessTokenExpirationMinutes = resultModel.AccessTokenExpirationMinutes,
                    RefreshTokenExpirationMinutes = resultModel.RefreshTokenExpirationMinutes,
                    TokenType = EJwtTokenType.Barrier.ToDescription()
                }
            };
        }

        //protected string CreateLogMessage(params string[] messages)
        //{
        //    var logMessage = new StringBuilder();

        //    foreach (var message in messages)
        //        logMessage.Append(message + AppConsts.LogSplitter);

        //    return logMessage.ToString();
        //}

        //private async Task InsertActiveAccessTokenAsync(string accessToken, string refreshToken, long accountId)
        //{
        //    //todo:AppType to access token
        //    await _accessTokenService.DeleteAndInsertTokenAsync(new ActiveAccessToken
        //    {
        //        TokenInfo = new TokenInfo
        //        {
        //            RefreshToken = refreshToken,
        //            AccessToken = accessToken,
        //            ExpirationDate = TokenHelper.ExpirationRefreshTokenDate,
        //        },
        //        IsActive = true,

        //        AccountId = accountId
        //    });

        //}

        //private static string GetGuid()
        //{
        //    return SecurityHelper.GetHashGuid();
        //}

    }
}