using AUA.ProjectName.Commands.Commands.Accounting.IdentityCommands.Login;
using AUA.ProjectName.Models.DynamicAggregate.Accounting;

namespace AUA.ProjectName.Services.GeneralService.Login.Contracts
{
    public interface IAccessTokenService
    {
        Task<LoginResponse> CreateAccountAccessToken(AccountLoginDto loginDto, Guid clientId);

        Task DeleteActiveAccessTokenAsync(long userId, int clientId);

    }
}
