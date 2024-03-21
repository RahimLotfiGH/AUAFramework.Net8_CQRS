using AUA.ProjectName.Commands.Commands.Accounting.AppUserCommands.Insert;
using AUA.ProjectName.Commands.Commands.Accounting.AppUserCommands.Update;
using AUA.ProjectName.DomainEntities.Entities.Accounting.AccountAggregate;
using AUA.ProjectName.DomainEntities.Entities.Accounting.AppUserAggregate;

namespace AUA.ProjectName.Commands.Mapping.Accounting
{
    public static class AppUserMaps
    {

        public static AppUser ToAppUser(this InsertAppUserCommand command)
        {
            return new AppUser
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
                IsActive = true,
                UserContact = new UserContact(command.Email, command.Phone)
            };

        }

        public static Account ToAccount(this InsertAppUserCommand command, long appUserId)
        {
            return new Account
            {
                UserName = command.UserName,
                AppUserId = appUserId,
                IsActive = true,
                PasswordCredential = new PasswordCredential(command.Password),

            };
        }

        public static void SetValues(this AppUser appUser, UpdateAppUserCommand command)
        {

            appUser.FirstName = command.FirstName;
            appUser.LastName = command.LastName;
            appUser.IsActive = true;
            appUser.UserContact = new UserContact(command.Email, command.Phone);

        }

    }
}
