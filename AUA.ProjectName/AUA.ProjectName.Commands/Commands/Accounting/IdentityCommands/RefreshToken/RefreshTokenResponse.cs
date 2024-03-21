namespace AUA.ProjectName.Commands.Commands.Accounting.IdentityCommands.RefreshToken
{
    public class RefreshTokenResponse
    {
        public string RefreshToken { get; set; }

        public DateTime ExpiresIn { get; set; }

        public string AccessToken { get; set; }

        public int AccessTokenExpirationMinutes { get; set; }

        public int RefreshTokenExpirationMinutes { get; set; }

        public string TokenType { get; set; }
    }
}
