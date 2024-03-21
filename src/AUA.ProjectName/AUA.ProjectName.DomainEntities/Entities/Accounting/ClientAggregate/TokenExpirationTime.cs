namespace AUA.ProjectName.DomainEntities.Entities.Accounting.ClientAggregate
{
    public record TokenExpirationTime
    {
        public int AccessTokenExpirationMinutes { get; set; }

        public int RefreshTokenExpirationMinutes { get; set; }

        public int NotBeforeMinutes { get; set; }

        
    }
}
