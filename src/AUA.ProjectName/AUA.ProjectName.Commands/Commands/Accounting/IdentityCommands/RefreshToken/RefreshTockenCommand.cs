using AUA.Infrastructure.CommandInfra.Command;

namespace AUA.ProjectName.Commands.Commands.Accounting.IdentityCommands.RefreshToken
{
    public class RefreshTokenCommand : BaseCommand<RefreshTokenResponse>
    {
        public string AccessToken { get; set; }

        public string RefreshToken { get; set; }

        public Guid? ClientId { get; set; }
    }
}
