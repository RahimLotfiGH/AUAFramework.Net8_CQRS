using AUA.Infrastructure.CommandInfra.Command;

namespace AUA.ProjectName.Commands.Commands.Accounting.IdentityCommands.Logout
{
    public class LogoutCommand : BaseCommand<bool>
    {
        public long UserId { get; set; }

        public int ClientId { get; set; }

    }
}
