using AUA.ProjectName.Common.Tools.Security;
using AUA.ProjectName.DomainEntities.Tools.Utilities;
using Microsoft.EntityFrameworkCore;

namespace AUA.ProjectName.DomainEntities.Entities.Accounting.AccountAggregate
{
    [Owned]
    public record PasswordCredential
    {
        public string Password { get; init; }

        public string Salt { get; init; }

        public PasswordCredential() { }//For EF framework

        public PasswordCredential(string password)
        {
            if (password is null)
                throw new ArgumentException("Password is nut null");

            Salt = SecurityHelper.GetHashGuid();
            Password = CreateAccountPassword(password.Trim());
            PasswordSecurityRate = PasswordSecurityRateHelper.GetSecurityRate(password);

        }

        public EPasswordSecurityRate PasswordSecurityRate { get; init; }

        public bool IsValidatePassword(string userPassword)
        {
            return Password == CreateAccountPassword(userPassword);
        }

        private string CreateAccountPassword(string password)
        {
            return EncryptionHelper.GetSha512Hash(password.Trim() + Salt);
        }

    }
}
