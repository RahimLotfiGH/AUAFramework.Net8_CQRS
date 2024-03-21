using AUA.Infrastructure.CommandInfra.Command;

namespace AUA.ProjectName.Commands.Commands.Accounting.AppUserCommands.Update
{
    public class UpdateAppUserCommand : BaseCommand<bool>
    {
        public long AppUserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

    }
}
