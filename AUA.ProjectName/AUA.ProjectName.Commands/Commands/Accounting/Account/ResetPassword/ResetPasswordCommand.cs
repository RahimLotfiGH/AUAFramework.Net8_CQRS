using AUA.Infrastructure.CommandInfra.Command;

namespace AUA.ProjectName.Commands.Commands.Accounting.Account.ResetPassword
{
    public class ResetPasswordCommand : BaseCommand<bool>
    {
        public long AccountId { get; set; }

    }
}
