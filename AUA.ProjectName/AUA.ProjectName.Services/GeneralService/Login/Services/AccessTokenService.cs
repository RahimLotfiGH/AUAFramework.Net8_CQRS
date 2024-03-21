using AUA.ProjectName.Commands.Commands.Accounting.IdentityCommands.Login;
using AUA.ProjectName.Common.Enums;
using AUA.ProjectName.Common.Extensions;
using AUA.ProjectName.Common.Tools.Security;
using AUA.ProjectName.DomainEntities.Entities.Accounting.ActiveAccessTokenAggregate;
using AUA.ProjectName.DomainEntities.Entities.Accounting.ClientAggregate;
using AUA.ProjectName.Models.DynamicAggregate.Accounting;
using AUA.ProjectName.Services.EntitiesService.Accounting.Contracts;
using AUA.ProjectName.Services.GeneralService.Login.Contracts;

namespace AUA.ProjectName.Services.GeneralService.Login.Services
{
    public class AccessTokenService : IAccessTokenService
    {

        private readonly IActiveAccessTokenService _activeAccessTokenService;
        private readonly IGenerateJwtService _generateJwtService;
        private readonly IClientService _clientService;
        private AccountLoginDto _loginDto;

        public AccessTokenService(IActiveAccessTokenService activeAccessTokenService
                                  , IGenerateJwtService generateJwtService
                                  , IClientService clientService)
        {
            _activeAccessTokenService = activeAccessTokenService;
            _generateJwtService = generateJwtService;
            _clientService = clientService;
        }


        public async Task<LoginResponse> CreateAccountAccessToken(AccountLoginDto loginDto, Guid clientId)
        {
            _loginDto = loginDto;

            var refreshToken = SecurityHelper.GetHashGuid();

            var client = await _clientService.GetClientByClientIdentityAsync(clientId);

            var accessToken = _generateJwtService.Generate(loginDto, client);

            await InsertActiveAccessTokenAsync(accessToken, refreshToken, client);

            return CreateLoginResponse(accessToken, refreshToken, client.ClientTokenExpiration);

        }
        private async Task InsertActiveAccessTokenAsync(string accessToken, string refreshToken, Client client)
        {
            var activeAccessToken = CreateActiveAccessToken(accessToken, refreshToken, client);

            await DeleteAndInsertTokenAsync(activeAccessToken);

        }

        private ActiveAccessToken CreateActiveAccessToken(string accessToken, string refreshToken, Client client)
        {
            return new ActiveAccessToken
            {
                TokenInfo = new TokenInfo
                {
                    RefreshToken = refreshToken,
                    AccessToken = accessToken,
                    ExpirationDate = DateTime.UtcNow.AddMinutes(client.ClientTokenExpiration.RefreshTokenExpirationMinutes),
                },
                IsActive = true,
                AccountId = _loginDto.Id,
                ClientId = client.Id
            };
        }

        public async Task DeleteAndInsertTokenAsync(ActiveAccessToken activeAccessToken)
        {
            await DeleteActiveAccessTokenAsync(activeAccessToken.AccountId, activeAccessToken.ClientId);

            await _activeAccessTokenService.InsertAsync(activeAccessToken);
        }

        public async Task DeleteActiveAccessTokenAsync(long accountId, int clintId)
        {
            await _activeAccessTokenService
                .DeleteAllActiveAccessTokensAsync(accountId, clintId);

        }

        private LoginResponse CreateLoginResponse(string accessToken, string refreshToken, TokenExpirationTime expirationTime)
        {
            return new LoginResponse
            {
                UserName = _loginDto.UserName,
                FirstName = _loginDto.FirstName,
                LastName = _loginDto.LastName,
                RoleIds = _loginDto.RoleIds,
                UserAccessCodes = _loginDto.UserAccessCodes,
                AccessToken = accessToken,
                ExpiresIn = DateTime.UtcNow.AddMinutes(expirationTime.AccessTokenExpirationMinutes),
                AccessTokenExpirationMinutes = expirationTime.AccessTokenExpirationMinutes,
                RefreshTokenExpirationMinutes = expirationTime.RefreshTokenExpirationMinutes,
                RefreshToken = refreshToken,
                TokenType = EJwtTokenType.Barrier.ToDescription()
            };
        }
    }
}
