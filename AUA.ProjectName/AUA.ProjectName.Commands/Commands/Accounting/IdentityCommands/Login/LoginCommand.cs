using AUA.Infrastructure.CommandInfra.Command;

namespace AUA.ProjectName.Commands.Commands.Accounting.IdentityCommands.Login
{
    public class LoginCommand : BaseCommand<LoginResponse>
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public Guid? ClientId { get; set; }

    }
}
