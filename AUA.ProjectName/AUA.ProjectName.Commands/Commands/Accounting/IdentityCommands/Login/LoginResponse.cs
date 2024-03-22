using AUA.ProjectName.DomainEntities.Entities.Accounting.UserAccessAggregate;

namespace AUA.ProjectName.Commands.Commands.Accounting.IdentityCommands.Login
{
    public class LoginResponse
    {
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public IEnumerable<int> RoleIds { get; set; }

        public IEnumerable<EUserAccess> UserAccessCodes { get; set; }


        public string TokenType { get; set; }

        public int AccessTokenExpirationMinutes { get; set; }

        public int RefreshTokenExpirationMinutes { get; set; }

        public DateTime ExpiresIn { get; set; }

        public string RefreshToken { get; set; }

        public string AccessToken { get; set; }

    }
}
